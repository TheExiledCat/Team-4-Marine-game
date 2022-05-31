using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressSlider : MonoBehaviour
{
    Slider m_Slider;

    private void Start()
    {
        m_Slider = gameObject.GetComponent<Slider>();
    }
    
    public void HandleSliderValue()
    {
        m_Slider.value = GameManager.GM.m_Progress;
    }
}
