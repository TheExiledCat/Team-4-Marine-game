using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityNode : MapNode
{
    [SerializeField]
    protected bool m_Activated;

    public void SetEnabled(bool _enabled)
    {
        m_Activated = _enabled;
    }

    public void ToggleEnabled()
    {
        m_Activated = !m_Activated;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawIcon(transform.position, "UtilityNode");
    }
}