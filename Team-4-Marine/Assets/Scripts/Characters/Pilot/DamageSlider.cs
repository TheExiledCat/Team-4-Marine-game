using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageSlider : MonoBehaviour
{
    Slider m_Slider;
    float m_Damage = 0;

    private void Start()
    {
        m_Slider = gameObject.GetComponent<Slider>();
    }

    public void HandleSliderValue()
    {
        m_Slider.value = m_Damage;
    }
}
