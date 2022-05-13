using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleButton : ButtonComponent
{
    private bool m_ToggledOn;

    [SerializeField] private Indicator m_Indicator;
    public void Set(bool _status)
    {
        m_ToggledOn = _status;
        SetIndicator();
    }
    public bool Get()
    {
        return m_ToggledOn;
    }
    public void Toggle()
    {
        m_ToggledOn = !m_ToggledOn;
        SetIndicator();
    }
    private void SetIndicator()
    {
        if (m_Indicator)
            m_Indicator.SetIndicator(m_ToggledOn);
    }
    public override void Initiate()
    {
        base.Initiate();
        m_Indicator.Initiate();
    }
    public override void Interact()
    {
        base.Interact();
        Toggle();
    }
}