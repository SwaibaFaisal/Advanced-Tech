using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class VoxelPlacer : MonoBehaviour
{
    #region variable info 
    [SerializeField] Vector3Int m_GridDimensions;
    [SerializeField] VoxelData m_InitialVoxel;
    [SerializeField] float m_cellSize;
    [SerializeField] Transform m_parentTransform;
    [SerializeField] GameObject m_obj;
    [SerializeField] List<GameObject> m_VoxelList = new List<GameObject>();
    [SerializeField] VoxelTypes m_voxelTypes;
    #endregion
    public VoxelTypes GetVoxelTypes => m_voxelTypes;

    void Awake()
    {
        InstantiateVoxels();
    }

    void InitVoxelList()
    {
        int _gridList = m_GridDimensions.x * m_GridDimensions.y * m_GridDimensions.z;

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
                    Vector3 _offset = new Vector3 (
                        (float)m_GridDimensions.x / 2, 
                        (float)m_GridDimensions.y / 2,
                        (float)m_GridDimensions.z / 2) 
                        * - 1;
                   // creates a gameobject to store voxel in temporarily

                   GameObject _obj = 
                    Instantiate(m_obj,
                        (m_parentTransform.position + _indexes + _offset), 
                        Quaternion.identity, m_parentTransform);

                    _obj.transform.localScale = new Vector3(m_cellSize, m_cellSize, m_cellSize);

                    m_VoxelList.Add(_obj);
                   
                    if(_obj.GetComponent<VoxelFunctionality>() != null)
                    {
                        VoxelFunctionality _script = _obj.GetComponent<VoxelFunctionality>();
                        _script.UpdateVoxelType(m_InitialVoxel);
                       
                    }

                }
            }
        }
    }

    public void OnBlockPlaced(Transform _transform, VoxelData _voxelData)
    {
            GameObject _obj =
                    Instantiate(m_obj,_transform.position,
                        _transform.rotation, m_parentTransform);

            _obj.transform.localScale = new Vector3(m_cellSize, m_cellSize, m_cellSize);

            m_VoxelList.Add(_obj);

            if (_obj.GetComponent<VoxelFunctionality>() != null)
            {
                VoxelFunctionality _script = _obj.GetComponent<VoxelFunctionality>();
                _script.UpdateVoxelType(_voxelData);
            }
    }

}
