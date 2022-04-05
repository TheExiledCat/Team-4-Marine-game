using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationDisplay : MonoBehaviour
{
    [SerializeField] private string m_StationName;

    private float m_DigitCrosses;

    public void SetCrosses(float _crosses)
    {
        m_DigitCrosses = _crosses;
    }

    public float GetCrosses()
    {
        return m_DigitCrosses;
    }
}