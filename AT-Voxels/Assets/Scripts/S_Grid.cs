using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
public class S_Grid : MonoBehaviour
{
    #region variable info 
    [SerializeField] Vector3Int m_GridDimensions;
    [SerializeField] Voxel m_airVoxel;
    [SerializeField] Voxel m_solidVoxel;
    [SerializeField] float m_cellSize;
    [SerializeField] Transform m_parentTransform;
    [SerializeField] GameObject m_obj;
    List<Voxel> m_VoxelList = new List<Voxel>();
    
    #endregion
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    void Start()
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
        for (int i = 0; i < m_GridDimensions.x; i++)
        {
            for (int j = 0; j < m_GridDimensions.y; j++)
            {
                for (int k = 0; k < m_GridDimensions.z; k++)
                {
                    Vector3 _indexes = new Vector3(i,j,k) * m_cellSize;
                    GameObject obj = 
                    Instantiate(m_obj,
                        (m_parentTransform.position + _indexes), 
                        Quaternion.identity, m_parentTransform);

                    obj.transform.localScale = new Vector3(m_cellSize, m_cellSize, m_cellSize);
                }
            }
        }
    }


}
