using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Handle : Selector
{
    private void Update()
    {
        if (m_Positions.Count > 0)
            transform.localEulerAngles = new Vector3(m_Positions[m_CurrentPosition], -90, 90);
    }
}