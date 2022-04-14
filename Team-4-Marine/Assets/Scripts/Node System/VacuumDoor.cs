using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class VacuumDoor : UtilityNode
{
    [SerializeField]
    private bool m_IsLocked = false;

    private void Update()
    {
        m_IsLocked = !m_Activated;
        GetComponent<BoxCollider2D>().enabled = m_IsLocked;
    }
}