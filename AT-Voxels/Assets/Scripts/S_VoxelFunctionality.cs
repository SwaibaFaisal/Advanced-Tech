using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VoxelFunctionality : MonoBehaviour
{
    [SerializeField] VoxelData m_currentVoxelData = null;
    [SerializeField] Material m_currentMaterial;
    [SerializeField] MeshRenderer m_meshRenderer;
    Vector3 m_index;
    [SerializeField] List<GameObject> m_faces = new List<GameObject>();



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

    public Vector3 GetIndex ()
    {
        return m_index;
    }    

    public void SetIndex(Vector3 _i)
    {
        m_index = _i;
        print(_i);
    }

}
