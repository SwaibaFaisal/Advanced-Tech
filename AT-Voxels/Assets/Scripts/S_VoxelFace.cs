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
    float m_scaleSize;
    bool m_isHighlighted;
    [SerializeField] float m_raycastDistance;
    [SerializeField] Transform m_originTransform;
    [SerializeField] List<GameObject> m_meshes = new List<GameObject>();
    

    Material m_currentMaterial;
    GameObject m_thisObject;
    E_VoxelFaceType m_type;

    public Transform GetOriginTransform => m_originTransform;

    private void Awake()
    {

    }

    public void UpdateOriginSpawnPoint(float _scaleFloat)
    {
        m_scaleSize = _scaleFloat;
        m_originTransform.position = m_originTransform.position + new Vector3(0,0,_scaleFloat/2);
    }
    public void UpdateHighlightState(bool _state)
    {
        m_isHighlighted = _state;
        print("changed to: " + _state);
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

    public void PlaceBlock(GameObject _object)
    {
        Instantiate(_object, new Vector3 (0,0,0), Quaternion.identity);
        print("placeBlock");

    }

}
