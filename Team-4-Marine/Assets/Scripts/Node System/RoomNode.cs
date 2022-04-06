using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class RoomNode : MapNode
{
    [SerializeField]
    protected Vector3 m_Size;

    [SerializeField]
    protected UtilityNode m_Affected;

    [SerializeField]
    private List<RepairStation> m_Stations = new List<RepairStation>();

    protected virtual void Start()
    {
        List<Collider2D> cols = Physics2D.OverlapBoxAll(transform.position, m_Size, 0).ToList();
        List<RepairStation> stations = new List<RepairStation>();
        foreach (Collider2D c in cols)
        {
            stations.Add(c.GetComponent<RepairStation>());
        }
        m_Stations = stations;
    }

    private void Update()
    {
        SetUtilities();
    }

    private void SetUtilities()
    {
        bool nodeIsFixed = true;
        foreach (RepairStation rs in m_Stations)
        {
            if (!rs.IsFixed())
            {
                nodeIsFixed = false;
            }
        }

        m_Affected.SetEnabled(nodeIsFixed);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, m_Size);
        Gizmos.DrawIcon(transform.position, "RoomNode");
    }
}