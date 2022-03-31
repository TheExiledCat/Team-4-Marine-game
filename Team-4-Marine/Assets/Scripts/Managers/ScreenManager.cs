using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    [SerializeField]
    CanvasGroup m_CockpitScreen, m_ManualScreen;

    Pilot.CockpitActions m_CockpitControls;
    Pilot.ManualActions m_ManualControls;

    bool m_ManualShown = false;

    private void Start()
    {
        m_CockpitControls = GameManager.GM.m_PilotControls.Cockpit;
        m_ManualControls = GameManager.GM.m_PilotControls.Manual;
        GameManager.GM.SetManualControls(false);
    }

    private void Update()
    {
        if (m_CockpitControls.ToManualScreen.WasPressedThisFrame())
        {
            m_ManualShown = true;
            ToggleScreens();
        }
        if (m_ManualControls.ToCockpitScreen.WasPressedThisFrame())
        {
            m_ManualShown = false;
            ToggleScreens();
        }
    }

    private void ToggleScreens()
    {
        if (m_ManualShown)
        {
            GameManager.GM.SetCockpitControls(false);
            m_CockpitScreen.alpha = 0;
            m_ManualScreen.alpha = 1;
            GameManager.GM.SetManualControls(true);
        }
        else
        {
            GameManager.GM.SetManualControls(false);
            m_ManualScreen.alpha = 0;
            m_CockpitScreen.alpha = 1;
            GameManager.GM.SetCockpitControls(true);
        }
    }
}
