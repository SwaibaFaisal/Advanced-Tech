using Unity.VisualScripting.FullSerializer;
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
    public Material m_material;
    [SerializeField] string m_name;
   // public Material Material { get { return m_material; } }
    public E_BlockType GetBlockType { get { return m_type; } }
    public Material GetMaterial { get { return m_material; } }
    public string Name { get { return m_name; } }
}
