using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manual : MonoBehaviour
{
    [SerializeField]
    Image m_PageImage;
    [SerializeField]
    List<Sprite> m_Pages;

    Pilot m_Pilot;
    int m_PageIndex;

    private void Awake()
    {
        m_Pilot = new Pilot();
        m_Pilot.Manual.Enable();
        m_PageIndex = 0;
    }

    private void Update()
    {
        if (m_Pilot.Manual.PageLeft.WasPressedThisFrame())
        {
           m_PageIndex--;
        }
        if (m_Pilot.Manual.PageRight.WasPressedThisFrame())
        {
           m_PageIndex++;
        }
        m_PageIndex = Mathf.Clamp(m_PageIndex, 0, m_Pages.Count - 1);
        SetPage();
    }

    private void SetPage()
    {
        m_PageImage.sprite = m_Pages[m_PageIndex];
    }
}
