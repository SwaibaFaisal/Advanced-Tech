using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class S_RotationControls : MonoBehaviour
{
    [SerializeField] GameObject m_objectToRotate;
    [SerializeField] Transform m_rotationPoint;
    [SerializeField] float m_rotationSpeed;
    [SerializeField] float m_verticalMultiplier;
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
            
        }

       
    }

    void MoveUpDown(float _speed)
    {
        float _value = (_speed / m_verticalMultiplier);

        m_objectToRotate.transform.position += new Vector3(0,_value,0);

    }

    void RotateLeftRight(float _speed)
    {
        Vector3 _angle = _speed * Vector3.up;
        /*m_objectToRotate.transform.RotateAround(m_rotationPoint.transform.position, Vector3.up, _speed);*/
        m_objectToRotate.transform.eulerAngles += _angle;
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
            MoveUpDown(m_rotateValues.y);
        }
        else if(_context.canceled)
        {
            m_isLookingVertical = false;
        }
    }

}
