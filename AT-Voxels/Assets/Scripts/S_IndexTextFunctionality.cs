using TMPro;
using UnityEngine;

public class S_IndexTextFunctionality : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_text;


    private void Awake()
    {
        m_text = this.GetComponent<TextMeshProUGUI>();
    }


    public void UpdateIndexText(Component _sender, object _data)
    { 
        if(_data is Vector3)
        {
            Vector3 _index = (Vector3) _data;
            m_text.text = _index.ToString();
        }
        else
        {
            m_text.text = null;
        }

    }

}
