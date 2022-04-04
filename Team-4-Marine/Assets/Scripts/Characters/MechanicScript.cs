using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechanicScript : MonoBehaviour
{
    [SerializeField]
    private RepairStation m_CurrentStation;
    private bool m_Repairing;

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
        if (m_CurrentStation != null && !m_CurrentStation.CheckForMechanic())
        {
            SetStation();
        }
        if (m_CurrentStation != null)
        {
            if (!m_Repairing)
            {
                print("Press Button to Interact");
                if (GameManager.GM.m_EngineerControls.Interactions.PrimaryInteract.WasPressedThisFrame())
                {
                    Repair();
                }
            }
            else
            {
                if (GameManager.GM.m_EngineerControls.Interactions.ReturnInteract.WasPressedThisFrame())
                {
                    Roam();
                }
            }
        }
    }

    private void Repair()
    {
        m_CurrentStation.Open();
        m_Repairing = true;
        GameManager.GM.SetMovement2DControls(false);
    }
    private void Roam()
    {
        m_CurrentStation.Close();
        m_Repairing = false;
        GameManager.GM.SetMovement2DControls(true);
    }
}