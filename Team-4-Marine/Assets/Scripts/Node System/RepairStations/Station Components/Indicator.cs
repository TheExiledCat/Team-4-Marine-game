using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    public bool m_LitUp = true;

    private Color m_OriginalColor;
    private Color m_TargetColor;

    public void Initiate()
    {
        m_OriginalColor = GetComponent<MeshRenderer>().material.GetColor("_EmissionColor");
        m_TargetColor = m_OriginalColor;
        print(m_OriginalColor);
        SetIndicator(m_LitUp);
    }

    public void SetIndicator(bool _status)
    {
        m_LitUp = _status;
        GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", m_LitUp ? m_TargetColor : Color.black);
    }

    public void SetIndicator(bool _status, Color _color)
    {
        m_LitUp = _status;
        GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", m_LitUp ? _color : Color.black);
    }

    public void ToggleIndicator()
    {
        m_LitUp = !m_LitUp;
        GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", m_LitUp ? m_TargetColor : Color.black);
    }
}