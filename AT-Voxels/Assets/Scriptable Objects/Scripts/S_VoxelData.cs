using UnityEngine;

public enum E_BlockType
{
    //0
    AIR,
    //1
    SOLID,

}

[CreateAssetMenu(menuName = "Voxel Object")]
public class VoxelData : ScriptableObject
{
    [SerializeField] E_BlockType m_type;
    [SerializeField] Material m_material;

    public Material GetMaterial { get { return m_material; } }
    public E_BlockType GetBlockType { get { return m_type; } }
}
