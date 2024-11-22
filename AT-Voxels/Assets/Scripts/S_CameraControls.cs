using UnityEngine;
using UnityEngine.InputSystem;

public enum E_RotationState
{
    //0
    NONE,
    //1
    UP,
    //2
    DOWN,
    //3
    LEFT,
    //4
    RIGHT,
}

public class S_CameraControls : MonoBehaviour
{
    [SerializeField] Transform m_targetTransform;
    [SerializeField] float m_rotationSpeed;
    E_RotationState m_rotationState;

    private void Update()
    {
        switch(m_rotationState)
        {
            case (E_RotationState)0:
                
                break;
            case (E_RotationState)1:
                RotateUpDown(1);
                break;
            case (E_RotationState)2:
                RotateUpDown(-1);
                break;
            case (E_RotationState)3:
                RotateLeftRight(-1);
                break;
            case (E_RotationState)4:
                RotateLeftRight(1);
                break;
        }
    }

    public void OnCameraLeftPressed(InputAction.CallbackContext _context)
    {
        if(_context.started)
        {
            m_rotationState = E_RotationState.LEFT;
        }
        if(_context.canceled)
        {
            m_rotationState = E_RotationState.NONE;
        }

    }

    public void OnCameraRightPressed(InputAction.CallbackContext _context)
    {
        if (_context.started)
        {
            m_rotationState = E_RotationState.RIGHT;
        }
        if (_context.canceled)
        {
            m_rotationState = E_RotationState.NONE;
        }
    }

   public void OnCameraUpPressed(InputAction.CallbackContext _context)
   {
        if (_context.started)
        {
            m_rotationState = E_RotationState.UP;
        }
        if (_context.canceled)
        {
            m_rotationState = E_RotationState.NONE;
        }
    }

   public void OnCameraDownPressed(InputAction.CallbackContext _context)
    {
        if (_context.started)
        {
            m_rotationState = E_RotationState.DOWN;
        }
        if (_context.canceled)
        {
            m_rotationState = E_RotationState.NONE;
        }
    }


    void RotateLeftRight(float _speed)
    {
        transform.RotateAround(m_targetTransform.position, new Vector3(0, 1, 0), _speed);
    }

    void RotateUpDown(float _speed)
    {
        transform.RotateAround(m_targetTransform.position, new Vector3(1, 0, 0), _speed);
    }


}
