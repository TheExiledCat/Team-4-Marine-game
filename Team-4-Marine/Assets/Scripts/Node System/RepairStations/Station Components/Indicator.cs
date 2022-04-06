using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    private bool m_LitUp;
    private Color m_OriginalColor;
    private void Start()
    {
    }
    public void Initiate()
    {
        m_OriginalColor = GetComponent<MeshRenderer>().material.GetColor("_EmissionColor");
    }
    private void Update()
    {
        if (GameManager.GM.m_EngineerControls.Interactions.PrimaryInteract.WasPressedThisFrame())
        {
            ToggleIndicator();
        }
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