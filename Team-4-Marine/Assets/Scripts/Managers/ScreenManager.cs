using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    [SerializeField]
    List<CameraPerspective> m_CameraPerspectives = new List<CameraPerspective>();
    int m_CurrentIndex;
    //index 0 = Cockpit perspective & index 1 = Manual perspective
    CameraPerspective m_CurrentPerspective;
    float m_TargetTime = 1.2f, m_CurrentTime, m_T;
    bool m_CameraIsMoving;

    [SerializeField]
    Camera m_Camera;

    Pilot.CockpitActions m_CockpitControls;
    Pilot.ManualActions m_ManualControls;

    bool m_ManualShown = false;

    private void Start()
    {
        m_CurrentIndex = 0;
        m_CurrentPerspective = m_CameraPerspectives[0];
        m_CockpitControls = GameManager.GM.m_PilotControls.Cockpit;
        m_ManualControls = GameManager.GM.m_PilotControls.Manual;
        GameManager.GM.SetManualControls(false);
    }

    private void Update()
    {
        m_CurrentTime += Time.deltaTime;
        
        if (m_CockpitControls.ToManualScreen.WasPressedThisFrame())
        {
            m_CurrentIndex++;
            m_ManualShown = true;
            ToggleScreens();
        }
        if (m_ManualControls.ToCockpitScreen.WasPressedThisFrame())
        {
            m_CurrentIndex--;
            m_ManualShown = false;
            ToggleScreens();
        }
        if (m_CameraIsMoving)
        {
            m_T = m_CurrentTime / m_TargetTime;
            m_T = Mathf.Clamp(m_T, 0, 1);
            m_CurrentIndex = Mathf.Clamp(m_CurrentIndex, 0, m_CameraPerspectives.Count);
            ChangePerspective(m_CurrentIndex);
        }
    }

    private void ToggleScreens()
    {
        m_CurrentTime = 0;
        if (m_ManualShown)
        {
            GameManager.GM.SetCockpitControls(false);
            GameManager.GM.SetManualControls(true);
        }
        else
        {
            GameManager.GM.SetManualControls(false);
            GameManager.GM.SetCockpitControls(true);
        }
        m_CameraIsMoving = true;
    }

    private void ChangePerspective(int _index)
    {
        m_Camera.transform.position = Vector3.Lerp(m_CurrentPerspective.m_PerspectiveBounds.center, m_CameraPerspectives[_index].m_PerspectiveBounds.center, m_T);
        m_Camera.transform.localEulerAngles = Vector3.Lerp(m_CurrentPerspective.m_CameraRotations, m_CameraPerspectives[_index].m_CameraRotations, m_T); 
        if(m_CurrentTime >= m_TargetTime)
        {
            m_CameraIsMoving = false;
            m_CurrentPerspective = m_CameraPerspectives[_index];
        }
    }
}
