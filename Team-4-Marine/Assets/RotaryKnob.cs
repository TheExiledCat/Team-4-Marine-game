using System;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider))]
public class RotaryKnob : Selector
{
    private void Update()
    {
        if (m_Positions.Count > 0)
            transform.localEulerAngles = new Vector3(-54, -90, m_Positions[m_CurrentPosition]);
    }
}