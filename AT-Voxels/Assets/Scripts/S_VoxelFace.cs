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
public class VoxelFace : MonoBehaviour
{
    [SerializeField] bool m_isAir;
    [SerializeField] float m_raycastDistance;
    [SerializeField] Transform m_raycastOrigin;
    Material m_currentMaterial;
    GameObject m_thisObject;
    MeshRenderer m_meshRenderer;
    E_VoxelFaceType m_type;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        m_meshRenderer = this.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    public void UpdateBaseMaterial(Material _newMaterial)
    {
        if(m_currentMaterial != _newMaterial) 
        { 
            m_meshRenderer.material = _newMaterial;
        }
        
    }

    public void UpdateAdditionalMaterials(int _index, Material _material)
    {
       Material[] _materialArray = m_meshRenderer.materials;
        _materialArray[1] = _material;

        m_meshRenderer.materials = _materialArray;
    }
}
