using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public enum E_VoxelType
{
    //0
    GRAY,
    //1
    RED,
    //2
    GREEN,

}

[CreateAssetMenu(menuName = "Voxel Object")]
public class VoxelData : ScriptableObject
{
    [SerializeField] E_VoxelType m_type;
    public Material m_material;
    [SerializeField] string m_name;
   // public Material Material { get { return m_material; } }
    public E_VoxelType GetBlockType { get { return m_type; } }
    public Material GetMaterial { get { return m_material; } }
    public string Name { get { return m_name; } }
}
