using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GM = null;
    public Pilot m_PilotControls;
    public Engineer m_EngineerControls;

    private void Awake()
    {
        if(GM == null)
        {
            GM = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        m_PilotControls = new Pilot();
        m_PilotControls.Enable();
        m_EngineerControls = new Engineer();
        m_EngineerControls.Enable();
    }

    public void SetCenterControls(bool _enabled)
    {
        if (_enabled)
        {
            m_PilotControls.Center.Enable();
        }
        else
        {
            m_PilotControls.Center.Disable();
        }
    }

    public void SetManualControls(bool _enabled)
    {
        if (_enabled)
        {
            m_PilotControls.Manual.Enable();
        }
        else
        {
            m_PilotControls.Manual.Disable();
        }
    }

    public void SetMovement2DControls(bool _enabled)
    {
        if (_enabled)
        {
            m_EngineerControls.Movement2D.Enable();
        }
        else
        {
            m_EngineerControls.Movement2D.Disable();
        }
    }
}
