using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacuumDoor : UtilityNode
{
    [SerializeField]
    private bool m_IsLocked = false;

    private void Update()
    {
        m_IsLocked = !m_Activated;
    }
}