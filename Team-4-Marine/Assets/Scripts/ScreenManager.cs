using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    [SerializeField]
    CanvasGroup m_CockpitScreen, m_ManualScreen;

    Pilot m_Pilot;

    bool m_ManualShown = false;

    private void Awake()
    {
        m_Pilot = new Pilot();
        m_Pilot.Cockpit.Enable();
    }

    private void Update()
    {
        if (m_Pilot.Cockpit.ToManualScreen.WasPressedThisFrame())
        {
            m_ManualShown = true;
            ToggleScreens();
        }
        if (m_Pilot.Manual.ToCockpitScreen.WasPressedThisFrame())
        {
            m_ManualShown = false;
            ToggleScreens();
        }
    }

    private void ToggleScreens()
    {
        if (m_ManualShown)
        {
            m_Pilot.Cockpit.Disable();
            m_CockpitScreen.alpha = 0;
            m_ManualScreen.alpha = 1;
            m_Pilot.Manual.Enable();
        }
        else
        {
            m_Pilot.Manual.Disable();
            m_ManualScreen.alpha = 0;
            m_CockpitScreen.alpha = 1;
            m_Pilot.Cockpit.Enable();
        }
    }
}
