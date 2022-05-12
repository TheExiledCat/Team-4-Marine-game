using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CockpitLights : MonoBehaviour
{
    [SerializeField]
    Indicator[] m_CockpitLights;

    float m_FlickerSpeed = 1;

    bool m_LightsOn = false;

    Indicator m_CurrentIndicator;

    private void Start()
    {
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

    private IEnumerator Flicker(Indicator _indicator)
    {
        while (m_LightsOn)
        {
            if (_indicator.m_LitUp)
            {
                _indicator.SetIndicator(false);
            }
            else
            {
                _indicator.SetIndicator(true);
            }
            yield return new WaitForSeconds(m_FlickerSpeed);
        }      
    }
}
