using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VoxelFunctionality : MonoBehaviour
{
    [SerializeField] VoxelData m_currentVoxelData = null;
    [SerializeField] Material m_currentMaterial;
    [SerializeField] Material m_HighlightMaterial;
    [SerializeField] bool m_isHighlighted = false;
    Vector3 m_index;
    [SerializeField] List<GameObject> m_faces = new List<GameObject>();

    public void UpdateVoxelType(VoxelData _newVoxelData)
    {
        if(m_currentVoxelData != _newVoxelData)
        {
            m_currentVoxelData = _newVoxelData;
            UpdateBaseMaterials(_newVoxelData.GetMaterial);
        }
    }

    public void SelectVoxel()
    {
        m_isHighlighted = true;
        UpdateHighlightedMaterial(0, m_HighlightMaterial);
    }

    public void DeselectVoxel()
    {
        m_isHighlighted = false;
    }

    public void UpdateHighlightedMaterial(int _index, Material _material)
    {
        for (int i = 0; i <  m_faces.Count; i++) 
        {
            VoxelFace _script = m_faces[i].GetComponent<VoxelFace>();
            _script.UpdateAdditionalMaterials(_index, _material);
        }
    }



    public void UpdateBaseMaterials(Material _material)
    {

        for(int i = 0;  i < m_faces.Count; i++)
        {
            VoxelFace _script = m_faces[i].GetComponent<VoxelFace>();
            _script.UpdateBaseMaterial(_material);
        }

    }

    public Vector3 GetIndex ()
    {
        return m_index;
    }    

    public void SetIndex(Vector3 _i)
    {
        m_index = _i;
       // print(_i);
    }

}
