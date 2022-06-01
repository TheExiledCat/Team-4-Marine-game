using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class RoomNode : MapNode
{
    [SerializeField]
    protected Vector3 m_Size;

    [SerializeField]
    protected List<UtilityNode> m_Affected;

    public DamageState m_DamageState = 0;

    [SerializeField]
    private List<RepairStation> m_Stations = new List<RepairStation>();

    protected override void Start()
    {
        base.Start();
        List<Collider2D> cols = Physics2D.OverlapBoxAll(transform.position, m_Size, 0).ToList();
        List<RepairStation> stations = new List<RepairStation>();
        foreach (Collider2D c in cols)
        {
            if (c.GetComponent<RepairStation>() != null)
            {
                stations.Add(c.GetComponent<RepairStation>());
            }
        }
        m_Stations = stations;
    }

    private void Update()
    {
        SetUtilities();
    }

    public void TakeDamage(int m_StationsToDamage)
    {
        int stationsLeft = m_StationsToDamage > TotalStations() ? TotalStations() : m_StationsToDamage;
        foreach (RepairStation r in m_Stations)
        {
            if (r.IsFixed() == true)
            {
                r.InitiatePuzzle();
                stationsLeft--;
            }
            if (stationsLeft <= 0)
            {
                return;
            }
        }
    }

    public int TotalStations()
    {
        return m_Stations.Count;
    }

    public int TotalBrokenStations()
    {
        int count = 0;
        foreach (RepairStation r in m_Stations)
        {
            count += r.IsFixed() ? 0 : 1;
        }
        return count;
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
        if (TotalBrokenStations() == TotalStations()) m_DamageState = DamageState.FATAL;
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
        foreach (UtilityNode u in m_Affected)
        {
            u.SetEnabled(nodeIsFixed);
        }
    }

    protected override void OnDrawGizmos()
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
    CRITICAL,
    FATAL
}