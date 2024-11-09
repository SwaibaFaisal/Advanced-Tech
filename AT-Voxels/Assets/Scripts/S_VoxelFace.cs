using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
public enum E_VoxelFaceType 
{ 
    FRONT,

    BACK,

    TOP,

    BOTTOM,

    LEFT,

    RIGHT,
};
public class VoxelFace : MonoBehaviour
{
    [SerializeField] bool m_isAir;
    [SerializeField] float m_raycastDistance;
    [SerializeField] Transform m_raycastOrigin;
    [SerializeField] List<GameObject> m_meshes = new List<GameObject>();


    Material m_currentMaterial;
    GameObject m_thisObject;
    E_VoxelFaceType m_type;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    public void UpdateBaseMaterial(Material _newMaterial)
    {
        if(m_currentMaterial != _newMaterial) 
        { 
            for (int i = 0; i < m_meshes.Count; i++)
            {
                MeshRenderer _meshRenderer = m_meshes[i].GetComponent<MeshRenderer>();
                _meshRenderer.material = _newMaterial;
            }

            
        }
        
    }


    public void UpdateAdditionalMaterials(int _index, Material _material)
    {
        for(int i = 0; i < m_meshes.Count; i++) 
        { 
           MeshRenderer _meshRenderer = m_meshes[i].GetComponent<MeshRenderer>();
           Material[] _materialArray = _meshRenderer.materials;
          
           _materialArray[_index] = _material; 
           _meshRenderer.materials = _materialArray;
                
        }       
    }


}
