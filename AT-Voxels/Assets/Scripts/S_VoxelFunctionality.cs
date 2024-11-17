using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VoxelFunctionality : MonoBehaviour
{
    [SerializeField] VoxelData m_currentVoxelData = null;
    [SerializeField] Material m_currentMaterial;
    [SerializeField] Material m_highlightMaterial;
    [SerializeField] Material m_blankMaterial;
    [SerializeField] bool m_isAir = false;
    
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

    void ToggleColliders()
    {
        if (m_isAir)
        {
            for(int i = 0; i < m_faces.Count; i++)
            {
                m_faces[i].GetComponent<Collider>().enabled = false;
            }
        }
        else
        {
            for (int i = 0; i < m_faces.Count; i++)
            {
                m_faces[i].GetComponent<Collider>().enabled = true;
            }

        }

    }

    public void SelectVoxel()
    {
       
        UpdateHighlightedMaterial(1, m_highlightMaterial);
    }

    public void DeselectVoxel()
    {
     
       UpdateHighlightedMaterial(1,null);
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

    }

    public void Break()
    {
        Destroy(this.gameObject);
    }

    public void Paint(VoxelData _voxelData)
    {
        UpdateBaseMaterials(_voxelData.GetMaterial);
    }

}
