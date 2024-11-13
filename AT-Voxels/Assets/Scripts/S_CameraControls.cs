using UnityEngine;
using UnityEngine.InputSystem;

public class S_CameraControls : MonoBehaviour
{
    [SerializeField] Transform m_targetTransform;
    [SerializeField] float m_rotationSpeed;

    public void OnCameraLeftPressed(InputAction.CallbackContext _context)
    {
        RotateLeftRight(m_rotationSpeed);
    }

    public void OnCameraRightPressed(InputAction.CallbackContext _context)
    {
        RotateLeftRight(-m_rotationSpeed);
    }

   public void OnCameraUpPressed(InputAction.CallbackContext _context)
   {
        RotateUpDown(m_rotationSpeed);
   }

   public void OnCameraDownPressed(InputAction.CallbackContext _context)
    {
        RotateUpDown(-m_rotationSpeed);
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
