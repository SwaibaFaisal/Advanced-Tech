using UnityEngine;
using UnityEngine.InputSystem;

public class SelectionScript : MonoBehaviour
{

    Camera m_cam;
    [SerializeField] LayerMask m_hittableLayer;
    [SerializeField] VoxelFunctionality m_previousScript;
    [SerializeField] VoxelFunctionality m_currentScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_cam = Camera.main;
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
                }
                else if(m_currentScript.GetIndex() != m_previousScript.GetIndex())
                {
                    m_previousScript.DeselectVoxel();
                    m_currentScript.SelectVoxel();
                    m_previousScript = m_currentScript;
                }

            }
            
        }
        else if(m_previousScript != null)
        {
            m_previousScript.DeselectVoxel();
            m_currentScript = null;
        }
       
    }

    public void OnVoxelClicked(InputAction.CallbackContext _context)
    {
        if(m_currentScript != null)
        {
            m_currentScript.Clicked();

        }


    }
    

}
