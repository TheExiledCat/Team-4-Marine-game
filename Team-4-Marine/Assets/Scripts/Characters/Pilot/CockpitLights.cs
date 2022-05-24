using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CockpitLights : MonoBehaviour
{
    [SerializeField]
    Indicator[] m_CockpitLights;

    float m_FlickerSpeed = 1;
    float m_Intensity = 5.5f;

    bool m_LightsOn = false;

    Indicator m_CurrentIndicator;
    Color m_CurrentColor;

    private void Start()
    {
        m_Intensity = Mathf.Pow(2, m_Intensity)/2;
        m_LightsOn = true;
        foreach(Indicator i in m_CockpitLights)
        {
            i.Initiate();
        }

        foreach(Indicator i in m_CockpitLights)
        {
            m_CurrentIndicator = i;
            StartCoroutine(Flicker(m_CurrentIndicator));
        }
    }

    private void Update()
    {
        switch (GameManager.GM.m_ChaosGradient)
        {
            case float i when (i <= 0.3):
                m_CurrentColor = Color.green * m_Intensity;
                m_FlickerSpeed = 3;
                break;
            case float i when (i > 0.3 && i < 0.7):
                m_CurrentColor = Color.yellow * m_Intensity;
                m_FlickerSpeed = 1;
                break;
            case float i when (i >= 0.7):
                m_CurrentColor = Color.red * m_Intensity;
                m_FlickerSpeed = 0.5f;
                break;
        }
    }

    private IEnumerator Flicker(Indicator _indicator)
    {
        while (m_LightsOn)
        {
            if (_indicator.m_LitUp)
            {
                _indicator.SetIndicator(false, m_CurrentColor);
            }
            else
            {
                _indicator.SetIndicator(true, m_CurrentColor);
            }
            yield return new WaitForSeconds(m_FlickerSpeed);
        }      
    }
}
