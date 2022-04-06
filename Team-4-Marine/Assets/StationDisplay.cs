using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class StationDisplay : PuzzleComponent
{
    [SerializeField] private string m_StationName;
    [SerializeField]
    private int m_DigitCrosses;
    [SerializeField]
    private TMP_Text m_TextName, m_Crosses, m_FreeText;

    private void Awake()
    {
        m_TextName.text = m_StationName;
        print(m_Crosses.name);
    }
    public override void Randomize()
    {
        SetCrosses(Mathf.FloorToInt(UnityEngine.Random.Range(1, 4)));
    }
    public void SetCrosses(int _crosses)
    {
        m_DigitCrosses = _crosses;
        string x = "";
        for (int i = 0; i < m_DigitCrosses; i++)
        {
            x += "X";
        }
        m_Crosses.text = x;
    }
    public void SetState(bool _fixed)
    {
        print("Setting");
        if (_fixed)
        {
            m_FreeText.text = "Working";
            m_FreeText.color = Color.green;
        }
        else
        {
            m_FreeText.text = "Malfunctioning";
            m_FreeText.color = Color.red;
        }
    }
    public float GetCrosses()
    {
        return m_DigitCrosses;
    }
}