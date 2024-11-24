using UnityEngine;
using UnityEngine.InputSystem;

public class S_RotationControls : MonoBehaviour
{
    [SerializeField] GameObject m_objectToRotate;
    [SerializeField] Transform m_rotationPoint;
    [SerializeField] float m_rotationSpeed;
    E_RotationStateHorizontal m_rotationStateHorizontal;
    E_RotationStateVertical m_rotationStateVertical;
    
  
    // Update is called once per frame
    void Update()
    {
        switch (m_rotationStateHorizontal)
        {
            case (E_RotationStateHorizontal)0:
                
                break;
            case (E_RotationStateHorizontal)2:
                print("left");
                RotateLeftRight(-1);
                break;
            case (E_RotationStateHorizontal)3:
                RotateLeftRight(1);
                break;

        }

        switch (m_rotationStateVertical)
        {
            case (E_RotationStateVertical)0:

                break;
            case (E_RotationStateVertical)2:
                RotateUpDown(-1);
                break;
            case (E_RotationStateVertical)3:
                RotateUpDown(1);
                break;

        }
    }

    void RotateUpDown(float _speed)
    {
        m_objectToRotate.transform.RotateAround(m_rotationPoint.position, new Vector3(1, 0, 0), _speed);
    }

    void RotateLeftRight(float _speed)
    {
        m_objectToRotate.transform.RotateAround(m_rotationPoint.position, new Vector3(0, 0, 1), _speed);
    }




    public void OnCameraLeftPressed(InputAction.CallbackContext _context)
    {
        if (_context.started)
        {
            m_rotationStateHorizontal = E_RotationStateHorizontal.LEFT;
        }
        if (_context.canceled)
        {
            m_rotationStateHorizontal = E_RotationStateHorizontal.NONE;
        }

    }

    public void OnCameraRightPressed(InputAction.CallbackContext _context)
    {
        if (_context.started)
        {
            m_rotationStateHorizontal = E_RotationStateHorizontal.RIGHT;
        }
        if (_context.canceled)
        {
            m_rotationStateHorizontal = E_RotationStateHorizontal.NONE;
        }
    }

    public void OnCameraUpPressed(InputAction.CallbackContext _context)
    {
        if (_context.started)
        {
            m_rotationStateVertical = E_RotationStateVertical.UP;
        }
        if (_context.canceled)
        {
            m_rotationStateVertical = E_RotationStateVertical.NONE;
        }
    }

    public void OnCameraDownPressed(InputAction.CallbackContext _context)
    {
        if (_context.started)
        {
            m_rotationStateVertical = E_RotationStateVertical.DOWN;
        }
        if (_context.canceled)
        {
            m_rotationStateVertical = E_RotationStateVertical.NONE;
        }
    }



}
