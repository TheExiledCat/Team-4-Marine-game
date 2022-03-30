using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityNode : MapNode
{
    private bool m_Enabled;

    public void SetEnabled(bool _enabled)
    {
        m_Enabled = _enabled;
    }
    public void ToggleEnabled()
    {
        m_Enabled = !m_Enabled;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawIcon(transform.position, "UtilityNode");
    }
}