using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressSlider : MonoBehaviour
{
    private Image m_Slider;

    private void Start()
    {
        m_Slider = gameObject.GetComponent<Image>();
    }

    private void Update()
    {
        m_Slider.fillAmount = GameManager.GM.m_Progress;
    }
}