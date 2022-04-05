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
    private TMP_Text m_TextName;
    private TMP_Text m_Crosses;
    private void Start()
    {
        m_TextName = transform.GetChild(1).GetComponent<TMP_Text>();
        m_Crosses = transform.GetChild(2).GetComponent<TMP_Text>();
        m_TextName.text = m_StationName;
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

    public float GetCrosses()
    {
        return m_DigitCrosses;
    }
}