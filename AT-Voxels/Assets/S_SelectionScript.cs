using UnityEngine;

public class SelectionScript : MonoBehaviour
{

    Camera m_cam;
    [SerializeField] LayerMask m_hittableLayer;
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

        if(Physics.Raycast(_ray, out RaycastHit _hitData, 100, m_hittableLayer))
        {
            print("hit face");
        }
       
    }
}
