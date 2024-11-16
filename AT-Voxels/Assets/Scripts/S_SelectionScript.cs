using UnityEngine;
using UnityEngine.InputSystem;

public enum E_BrushType 
{ 
    //0
    PAINT,
    //1
    ERASE,
    //2
    PLACE,

}


public class SelectionScript : MonoBehaviour
{
    Camera m_cam;
    [SerializeField] LayerMask m_hittableLayer;
    [SerializeField] VoxelFunctionality m_previousScript;
    [SerializeField] VoxelFunctionality m_currentScript;
    [SerializeField] VoxelData m_airVoxel;
    [SerializeField] VoxelData m_solidVoxel;
    [SerializeField] GameEvent m_indexChangedEvent;
    bool m_eraserOn = false;
    E_BrushType m_brushType;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_cam = Camera.main;
        m_brushType = E_BrushType.PAINT;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 _mousePosition = Input.mousePosition;

        Ray _ray = Camera.main.ScreenPointToRay(_mousePosition);

        // does a raycast from parent's transform to the object the mouse is hovering over. 
        // if the object has the correct layer mask, check for Voxel script in object's parent
        // if script is found, run "select voxel" function

        if(Physics.Raycast(_ray, out RaycastHit _hitData, 100, m_hittableLayer))
        {
           m_currentScript = 
                _hitData.collider.gameObject.GetComponentInParent<VoxelFunctionality>();
            

            if( m_currentScript  != null )
            {
                if(m_previousScript == null)
                {
                    m_currentScript.SelectVoxel();
                    m_previousScript = m_currentScript;
                    m_indexChangedEvent.Raise(this, m_currentScript.GetIndex());
                }
                else if(m_currentScript.GetIndex() != m_previousScript.GetIndex())
                {
                    m_previousScript.DeselectVoxel();
                    m_currentScript.SelectVoxel();
                    m_previousScript = m_currentScript;
                    m_indexChangedEvent.Raise(this, m_currentScript.GetIndex());
                }

            }
            
        }
        else if(m_previousScript != null)
        {
            m_previousScript.DeselectVoxel();
            m_currentScript = null;
            m_indexChangedEvent.Raise(this, null);
        }
       
    }

    public void ToggleBrushType()
    {
       if((int)m_brushType <= 1)
       {
            m_brushType += 1;
       }
       else
       {
            m_brushType = 0;
       }

       
    }

    public void OnVoxelClicked(InputAction.CallbackContext _context)
    {
        if(_context.started && m_currentScript != null)
        {
            switch(m_brushType)
            {
                case (E_BrushType)0:
                    m_currentScript.Paint(m_airVoxel);
                    break;
                case (E_BrushType)1:
                    m_currentScript.Break();
                    break;
                case (E_BrushType)2:
                    print("place block");
                    break;
            }


         
        }
    }


}
