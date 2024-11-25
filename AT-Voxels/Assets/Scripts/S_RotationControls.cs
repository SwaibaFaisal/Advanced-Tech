using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class S_RotationControls : MonoBehaviour
{
    [SerializeField] GameObject m_objectToRotate;
    [SerializeField] Transform m_rotationPoint;
    [SerializeField] float m_rotationSpeed;
    Vector2 m_rotateValues; 
    bool m_isLookingHorizontal;
    bool m_isLookingVertical;
    
  
    // Update is called once per frame
    void Update()
    {
        if(m_isLookingHorizontal)
        {
            RotateLeftRight(m_rotateValues.x);
        }

        if(m_isLookingVertical)
        {
            RotateUpDown(m_rotateValues.y);
        }

       
    }

    void RotateUpDown(float _speed)
    {

        Vector3 _angle = _speed * Vector3.right;
        m_objectToRotate.transform.Rotate(_angle);

    }

    void RotateLeftRight(float _speed)
    {


        Vector3 _angle = _speed * Vector3.up;
        m_objectToRotate.transform.Rotate(_angle);

    }


    public void OnLookHorizontal(InputAction.CallbackContext _context)
    {
        if(_context.started)
        { 
           m_isLookingHorizontal = true;
           m_rotateValues.x = _context.ReadValue<float>();

        }
        else if(_context.canceled)
        {
            m_isLookingHorizontal = false;
        }
        
    }

    public void OnLookVertical(InputAction.CallbackContext _context)
    { 
        if(_context.started)
        {
            m_isLookingVertical = true;
            m_rotateValues.y = _context.ReadValue<float>();
        }
        else if(_context.canceled)
        {
            m_isLookingVertical = false;
        }
    }

}
