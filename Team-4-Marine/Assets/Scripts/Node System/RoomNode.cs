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

    public DamageState m_DamageState = 0;

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

    private void UpdateDamageState(float _amountPercentage)
    {
        if (_amountPercentage >= 0.5f)
        {
            if (_amountPercentage == 1)
            {
                m_DamageState = DamageState.FULL;
                return;
            }
            m_DamageState = DamageState.DAMAGED;
            return;
        }
        m_DamageState = DamageState.CRITICAL;
        return;
    }

    private void SetUtilities()
    {
        int totalStations = 0;
        int fixedStations = 0;
        bool nodeIsFixed = true;
        foreach (RepairStation rs in m_Stations)
        {
            totalStations++;
            fixedStations++;
            if (!rs.IsFixed())
            {
                nodeIsFixed = false;
                fixedStations--;
            }
        }
        UpdateDamageState((float)fixedStations / (float)totalStations);
        print(fixedStations + " out of " + totalStations + " are working");
        m_Affected.SetEnabled(nodeIsFixed);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, m_Size);
        Gizmos.DrawIcon(transform.position, "RoomNode");
    }
}

public enum DamageState
{
    FULL,
    DAMAGED,
    CRITICAL
}