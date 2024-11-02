using TMPro;
using UnityEngine;

public class VoxelFunctionality : MonoBehaviour
{
    [SerializeField] VoxelData m_currentVoxelData = null;
    [SerializeField] Material m_currentMaterial;
    [SerializeField] MeshRenderer m_meshRenderer;
    int m_index;

    public int index { get { return m_index; } }


   public void UpdateVoxelType(VoxelData _newVoxelData)
   {
        if(m_currentVoxelData != _newVoxelData)
        {
            m_currentVoxelData = _newVoxelData;
            UpdateMaterial(_newVoxelData.GetMaterial);
            
        }

   }

    public void UpdateMaterial(Material _material)
    {
        m_meshRenderer.material = _material;
    }
}
