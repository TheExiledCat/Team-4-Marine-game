using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    public bool m_LitUp;
    private Color m_OriginalColor;

    public void Initiate()
    {
        m_OriginalColor = GetComponent<MeshRenderer>().material.GetColor("_EmissionColor");
    }

    public void SetIndicator(bool _status)
    {
        m_LitUp = _status;
        GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", m_LitUp ? m_OriginalColor : Color.black);
    }

    public void ToggleIndicator()
    {
        m_LitUp = !m_LitUp;
        GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", m_LitUp ? m_OriginalColor : Color.black);
    }
}