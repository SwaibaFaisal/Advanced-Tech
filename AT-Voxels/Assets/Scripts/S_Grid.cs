using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
public class S_Grid : MonoBehaviour
{
    #region variable info 
    [SerializeField] Vector3Int m_GridDimensions;
    [SerializeField] VoxelData m_airVoxel;
    [SerializeField] VoxelData m_solidVoxel;
    [SerializeField] float m_cellSize;
    [SerializeField] Transform m_parentTransform;
    [SerializeField] GameObject m_obj;
    [SerializeField] List<VoxelData> m_VoxelList = new List<VoxelData>();
    
    #endregion
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    void Awake()
    {
        InitVoxelList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitVoxelList()
    {
        int _gridList = m_GridDimensions.x * m_GridDimensions.y * m_GridDimensions.z;

        for (int i = 0; i < _gridList; i++) 
        { 
           m_VoxelList.Add(m_airVoxel); 
        }

        InstantiateVoxels();

    }

    void InstantiateVoxels()
    {
        // loops through 3 dimensions and adds a voxel 
        for (int i = 0; i < m_GridDimensions.x; i++)
        {
            for (int j = 0; j < m_GridDimensions.y; j++)
            {
                for (int k = 0; k < m_GridDimensions.z; k++)
                {
                    Vector3 _indexes = new Vector3(i,j,k) * m_cellSize;
                    
                   // creates a gameobject to store voxel in temporarily

                   GameObject _obj = 
                    Instantiate(m_obj,
                        (m_parentTransform.position + _indexes), 
                        Quaternion.identity, m_parentTransform);

                    _obj.transform.localScale = new Vector3(m_cellSize, m_cellSize, m_cellSize);
                   
                    if(_obj.GetComponent<VoxelFunctionality>() != null)
                    {
                        VoxelFunctionality _script = _obj.GetComponent<VoxelFunctionality>();

                        _script.UpdateVoxelType(m_airVoxel);

                    }

                }
            }
        }
    }


}
