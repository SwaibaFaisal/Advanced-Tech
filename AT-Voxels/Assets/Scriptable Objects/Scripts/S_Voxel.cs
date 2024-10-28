using UnityEngine;

public enum E_BlockType
{
    //0
    AIR,
    //1
    SOLID,

}

[CreateAssetMenu(menuName = "Voxel")]
public class Voxel : ScriptableObject
{
    [SerializeField] E_BlockType m_type;
    [SerializeField] Material m_material;
}
