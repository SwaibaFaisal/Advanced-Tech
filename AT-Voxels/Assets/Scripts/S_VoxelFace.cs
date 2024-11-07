using UnityEngine;
public enum E_VoxelFaceType 
{ 
    FRONT,

    BACK,

    TOP,

    BOTTOM,

    LEFT,

    RIGHT,
};
public class S_VoxelFace : MonoBehaviour
{
    [SerializeField] bool m_isAir;
    [SerializeField] float m_raycastDistance;
    [SerializeField] Transform m_raycastOrigin;
    GameObject m_thisObject;
    SpriteRenderer m_spriteRenderer;
    E_VoxelFaceType m_type;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        m_spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
