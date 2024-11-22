using UnityEngine;
[CreateAssetMenu(menuName = "Voxel Types")]
public class VoxelTypes : ScriptableObject
{
    [SerializeField] VoxelData m_grayVoxel;
    [SerializeField] VoxelData m_redVoxel;
    [SerializeField] VoxelData m_greenVoxel;

    public VoxelData GetGrayVoxel => m_grayVoxel;
    public VoxelData GetRedVoxel => m_redVoxel;
    public VoxelData GetGreenVoxel => m_greenVoxel;
}
