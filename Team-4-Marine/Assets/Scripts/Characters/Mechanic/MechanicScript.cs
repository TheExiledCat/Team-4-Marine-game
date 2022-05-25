using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechanicScript : MonoBehaviour
{
    [SerializeField]
    private RepairStation m_CurrentStation;
    [SerializeField] Camera m_EngineerCam;
    [SerializeField] private LayerMask m_Interactables;
    private bool m_Repairing;

    public void SetStation(RepairStation _station = null)
    {
        m_CurrentStation = _station;
    }

    public bool m_CanInteract = true;

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
                if (GameManager.GM.m_EngineerControls.Interactions.PrimaryInteract.WasPressedThisFrame() && m_CurrentStation.IsFixed() == false)
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
        Interact();
    }

    private void FixedUpdate()
    {
    }

    private void Interact()
    {
        if (m_CanInteract)
        {
            if (GameManager.GM.m_EngineerControls.Interactions.MouseInteract.WasPressedThisFrame())
            {
                //print("CLick");
                RaycastHit hit;

                if (Physics.Raycast(m_EngineerCam.ScreenPointToRay(Input.mousePosition), out hit, 10000, m_Interactables))
                {
                    // print(hit.collider.gameObject.name);
                    hit.collider.gameObject.GetComponent<Interactable>().Interact();
                }
            }
            else if (GameManager.GM.m_EngineerControls.Interactions.MouseSecondaryInteract.WasPressedThisFrame())
            {
                //print("CLick");
                RaycastHit hit;

                if (Physics.Raycast(m_EngineerCam.ScreenPointToRay(Input.mousePosition), out hit, 10000, m_Interactables))
                {
                    //print(hit.collider.gameObject.name);
                    hit.collider.gameObject.GetComponent<Interactable>().SecondaryInteract();
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

    public void Roam()
    {
        //if (m_CurrentStation.m_Opened)
        m_CurrentStation.Close();
        m_Repairing = false;
        GameManager.GM.SetMovement2DControls(true);
    }
}