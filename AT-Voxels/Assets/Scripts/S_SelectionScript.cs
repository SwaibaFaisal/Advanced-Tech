using UnityEngine;

public class SelectionScript : MonoBehaviour
{

    Camera m_cam;
    [SerializeField] LayerMask m_hittableLayer;
    [SerializeField] VoxelFunctionality m_previousScript;
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
           VoxelFunctionality _script = 
                _hitData.collider.gameObject.GetComponentInParent<VoxelFunctionality>();
            

            if( _script != null )
            {
                if(m_previousScript == null)
                {
                    _script.SelectVoxel();
                    m_previousScript = _script;
                }
                else if(_script.GetIndex() != m_previousScript.GetIndex())
                {
                    m_previousScript.DeselectVoxel();
                    _script.SelectVoxel();
                    m_previousScript = _script;
                }

            }
            
        }
        else if(m_previousScript != null)
        {
            m_previousScript.DeselectVoxel();
        }
        
       
    }

    

}
