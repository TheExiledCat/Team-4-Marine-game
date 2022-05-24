using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    [SerializeField]
    CameraPerspective m_ShootingPerspective;
    [SerializeField]
    List<CameraPerspective> m_CameraPerspectives = new List<CameraPerspective>();
    int m_CurrentIndex;
    //index 0 = record player perspective, index 1 = cockpit perspective & index 2 = manual perspective
    [SerializeField]
    CameraPerspective m_CurrentPerspective;
    [SerializeField]
    float m_TargetTime = 1, m_CurrentTime, m_T;
    [SerializeField]
    float m_CameraSpeed = 10;

    bool m_CameraIsMoving;
    bool m_ManualShown = false;
    bool m_RightStickPressed = false;

    [SerializeField]
    Camera m_Camera;

    Pilot.CockpitActions m_CockpitControls;
    Pilot.CenterActions m_CenterControls;
    Pilot.ShootingActions m_ShootingControls;

    Vector2 m_Axis;
    Vector3 m_CurrentCameraRotation;

    private void Start()
    {
        m_ShootingControls = GameManager.GM.m_PilotControls.Shooting;
        m_CurrentIndex = 1;
        m_CurrentPerspective = m_CameraPerspectives[1];
        m_CockpitControls = GameManager.GM.m_PilotControls.Cockpit;
        m_CenterControls = GameManager.GM.m_PilotControls.Center;
        GameManager.GM.SetManualControls(false);
        m_ShootingControls.Disable();
    }

    private void Update()
    {
        m_Axis = GameManager.GM.m_PilotControls.Cockpit.MoveCamera.ReadValue<Vector2>();

        MoveCamera();

        m_CurrentTime += Time.deltaTime;

        if (m_CenterControls.ZoomIn.WasPressedThisFrame())
        {
            m_CameraIsMoving = true;
            m_CurrentTime = 0;
            if (!m_RightStickPressed)
            {
                m_RightStickPressed = true;
                m_ShootingControls.Enable();
                m_CockpitControls.Disable();
            }
            else
            {
                m_RightStickPressed = false;
                m_ShootingControls.Disable();
                m_CockpitControls.Enable();
            }
        }

        if (m_CockpitControls.ToManualScreen.WasPressedThisFrame())
        {
            m_CurrentIndex++;
            m_ManualShown = true;
            ToggleScreens();
        }
        if (m_CockpitControls.ToCockpitScreen.WasPressedThisFrame())
        {
            m_CurrentIndex--;
            m_ManualShown = false;
            ToggleScreens();
        }
        m_CurrentIndex = Mathf.Clamp(m_CurrentIndex, 0, m_CameraPerspectives.Count - 1);
        if (m_CameraIsMoving)
        {
            m_T = m_CurrentTime / m_TargetTime;
            m_T = Mathf.Clamp(m_T, 0, 1);
            if (m_RightStickPressed)
            {
                ChangePerspective(m_ShootingPerspective, m_CurrentPerspective.m_PerspectiveBounds.center);
            }
            else
            {
                ChangePerspective(m_CurrentIndex);
            }
        }
    }

    private void MoveCamera()
    {
        float offsetX = m_CurrentPerspective.m_CameraRotations.x;
        float offsetY = m_CurrentPerspective.m_CameraRotations.y;
        m_Camera.transform.localEulerAngles += new Vector3(-m_Axis.y, m_Axis.x)*Time.deltaTime*m_CameraSpeed;
        Vector3 currentRotation = new Vector3(Mathf.Repeat(m_Camera.transform.localEulerAngles.x + 180, 360) - 180, Mathf.Repeat(m_Camera.transform.localEulerAngles.y + 180, 360) - 180);
        currentRotation = new Vector3(Mathf.Clamp(currentRotation.x, -m_CurrentPerspective.m_PerspectiveBounds.extents.x + offsetX, m_CurrentPerspective.m_PerspectiveBounds.extents.x + offsetX), Mathf.Clamp(currentRotation.y, -m_CurrentPerspective.m_PerspectiveBounds.extents.y + offsetY, m_CurrentPerspective.m_PerspectiveBounds.extents.y + offsetY));
        m_Camera.transform.localEulerAngles = currentRotation;
    }

    private void ToggleScreens()
    {
        m_CurrentIndex = Mathf.Clamp(m_CurrentIndex, 0, m_CameraPerspectives.Count - 1);
        m_CurrentTime = 0;
        if (m_ManualShown)
        {
            GameManager.GM.SetCenterControls(false);
            GameManager.GM.SetManualControls(true);
        }
        else
        {
            GameManager.GM.SetManualControls(false);
            GameManager.GM.SetCenterControls(true);
        }
        if(m_CurrentPerspective != m_CameraPerspectives[m_CurrentIndex])
        {
            m_CameraIsMoving = true;
        }
        m_CurrentCameraRotation = m_Camera.transform.localEulerAngles;
        m_CurrentCameraRotation.x = Mathf.Repeat(m_CurrentCameraRotation.x + 180, 360) - 180;
        m_CurrentCameraRotation.y = Mathf.Repeat(m_CurrentCameraRotation.y + 180, 360) - 180;
    }

    private void ChangePerspective(int _index)
    {
        m_Camera.transform.position = Vector3.Lerp(m_CurrentPerspective.m_PerspectiveBounds.center, m_CameraPerspectives[_index].m_PerspectiveBounds.center, m_T);
        m_Camera.transform.localEulerAngles = Vector3.Lerp(m_CurrentCameraRotation, m_CameraPerspectives[_index].m_CameraRotations, m_T); 
        if(m_CurrentTime >= m_TargetTime)
        {
            m_CameraIsMoving = false;
            m_CurrentPerspective = m_CameraPerspectives[_index];
        }
    }

    private void ChangePerspective(CameraPerspective _cameraPerspective, Vector3 _startPosition)
    {
        m_Camera.transform.position = Vector3.Lerp(_startPosition, _cameraPerspective.m_PerspectiveBounds.center, m_T);
        m_Camera.transform.localEulerAngles = Vector3.Lerp(m_CurrentCameraRotation, _cameraPerspective.m_CameraRotations, m_T);
        if (m_CurrentTime >= m_TargetTime)
        {
            m_CameraIsMoving = false;
        }
    }
}
