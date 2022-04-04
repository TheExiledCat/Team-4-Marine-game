using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechanicScript : MonoBehaviour
{
    [SerializeField]
    private RepairStation m_CurrentStation;

    public void SetStation(RepairStation _station = null)
    {
        m_CurrentStation = _station;
    }
    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (m_CurrentStation != null) print("Press Button to Interact");
        SetStation();
    }
}