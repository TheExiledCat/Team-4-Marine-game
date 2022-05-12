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
        foreach(Indicator i in m_CockpitLights)
        {
            i.Initiate();
        }

        foreach(Indicator i in m_CockpitLights)
        {
            m_CurrentIndicator = i;
            i.SetIndicator(true);
            Invoke("Flicker(m_CurrentIndicator)", m_FlickerSpeed);
        }
    }

    private void Flicker(Indicator _indicator)
    {
        if (_indicator.m_LitUp)
        {
            _indicator.SetIndicator(false);
        }
        else
        {
            _indicator.SetIndicator(true);
        } 
        Invoke("Flicker(_indicator)", m_FlickerSpeed);
    }
}
