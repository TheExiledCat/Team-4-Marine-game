using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollMonitor : MonoBehaviour
{
    [SerializeField]
    float m_MinValue = -225.6f, m_MaxValue = -82.4f, m_Position;

    [SerializeField]
    Vector2 m_Axis;

    private void Update()
    {
        m_Axis = GameManager.GM.m_PilotControls.Manual.MonitorScroll.ReadValue<Vector2>();
        m_Position -= m_Axis.y*Time.deltaTime;
        Scroll();
    }

    private void Scroll()
    {
        float value = Mathf.Lerp(m_MinValue, m_MaxValue, m_Position);
        m_Position = Mathf.Clamp(m_Position, 0, 1);
        gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(-98.7f, value);
        
    }
}
