using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomNode : MapNode
{
    [SerializeField]
    protected Vector3 m_Size;

    [SerializeField]
    protected UtilityNode m_Affected;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, m_Size);
        Gizmos.DrawIcon(transform.position, "RoomNode");
    }
}