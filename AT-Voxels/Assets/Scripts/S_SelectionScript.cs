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
   
    VoxelFunctionality m_previousVoxelScript;
    VoxelFunctionality m_currentVoxelScript;
    VoxelFace m_previousFaceScript;
    VoxelFace m_currentFaceScript;

    E_BrushType m_brushType;

    [SerializeField] LayerMask m_hittableLayer;
    [SerializeField] VoxelData m_airVoxel;
    [SerializeField] VoxelData m_solidVoxel;
    [SerializeField] GameEvent m_indexChangedEvent;
    [SerializeField] GameEvent m_blockPlacedEvent;

    RaycastHit m_rayCastHitData;
    
    bool m_eraserOn = false;
    
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_cam = Camera.main;
        m_brushType = E_BrushType.PAINT;
    }

    // Update is called once per frame
    void Update()
    {
        //revise, is it wise to mix modern + legacy input systems???????
        Vector3 _mousePosition = Input.mousePosition;

        Ray _ray = Camera.main.ScreenPointToRay(_mousePosition);

        TestRaycastFromCursor(_mousePosition);

        // does a raycast from parent's transform to the object the mouse is hovering over. 
        // if the object has the correct layer mask, check for Voxel script in object's parent
        // if script is found, run "select voxel" functionality

        if(Physics.Raycast(_ray, out RaycastHit _hitData, 100, m_hittableLayer))
        {

           m_rayCastHitData = _hitData;
           
            m_currentVoxelScript = 
                _hitData.collider.gameObject.GetComponentInParent<VoxelFunctionality>();
            m_currentFaceScript = 
                _hitData.collider.gameObject.GetComponentInParent<VoxelFace>();

            if (m_currentFaceScript == null)
            { print("null face script"); }

            if( m_currentVoxelScript  != null)
            {
                if(m_previousVoxelScript == null)
                {
                    m_currentVoxelScript.SelectVoxel();
                    m_previousVoxelScript = m_currentVoxelScript;

                    
                    m_previousFaceScript = m_currentFaceScript;

                    m_indexChangedEvent.Raise(this, m_currentVoxelScript.GetIndex());
                }
                else if(m_currentVoxelScript.GetIndex() != m_previousVoxelScript.GetIndex())
                {
                    m_previousVoxelScript.DeselectVoxel();
                    m_currentVoxelScript.SelectVoxel();
                    m_previousVoxelScript = m_currentVoxelScript;

                    
                    m_previousFaceScript = m_currentFaceScript;

                    m_indexChangedEvent.Raise(this, m_currentVoxelScript.GetIndex());
                }

            }
            
        }
        else if(m_previousVoxelScript != null)
        {
            m_previousVoxelScript.DeselectVoxel();
            m_currentVoxelScript = null;

            
            m_currentFaceScript = null;

            m_indexChangedEvent.Raise(this, null);
        }
       
    }

    public void BuildBlock()
    {
        m_blockPlacedEvent.Raise(this, m_currentFaceScript.GetOriginTransform);
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
        if(_context.started && m_currentVoxelScript != null)
        {
            switch(m_brushType)
            {
                case (E_BrushType)0:
                    m_currentVoxelScript.Paint(m_airVoxel);
                    break;
                case (E_BrushType)1:
                    m_currentVoxelScript.Break();
                    break;
                case (E_BrushType)2:
                    BuildBlock();
                    break;
            }


         
        }
    }


    private void TestRaycastFromCursor(Vector3 _mousePos)
    {
        
    }

}
