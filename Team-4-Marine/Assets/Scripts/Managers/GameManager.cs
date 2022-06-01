using System.Linq;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System;
public class GameManager : MonoBehaviour
{
    public static GameManager GM = null;
    public Pilot m_PilotControls;
    public Engineer m_EngineerControls;
    private List<RoomNode> m_Rooms = new List<RoomNode>();
    public float m_ChaosGradient = 0.5f;
    public float m_Progress = 0;
    private MechanicScript m_Mechanic;
    public event Action OnMeteorShower;

    private void Awake()
    {
        if (GM == null)
        {
            GM = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        m_PilotControls = new Pilot();
        m_PilotControls.Enable();
        m_EngineerControls = new Engineer();
        m_EngineerControls.Enable();
        m_Mechanic = FindObjectOfType<MechanicScript>();
    }

    private void Start()
    {
        MapNode[] nodes = FindObjectsOfType<MapNode>();
        for (int i = 0; i < nodes.Length; i++)
        {
            if (nodes[i] is RoomNode)
            {
                m_Rooms.Add(nodes[i] as RoomNode);
            }
        }
        print("Damaging");
        CauseShipDamage(5f, true);
        Invoke("CauseMeteorShower", 15 + 10 * m_ChaosGradient);
    }

    //UpdateGradient
    public void ForceRoam()
    {
        m_Mechanic.Roam();
    }

    public void DisableMechanicInteraction()
    {
        m_Mechanic.m_CanInteract = false;
    }

    public void EnableMechanicInteraction()
    {
        m_Mechanic.m_CanInteract = true;
    }

    public void SetCenterControls(bool _enabled)
    {
        if (_enabled)
        {
            m_PilotControls.Center.Enable();
        }
        else
        {
            m_PilotControls.Center.Disable();
        }
    }

    public void SetCockpitControls(bool _enabled)
    {
        if (_enabled)
        {
            m_PilotControls.Cockpit.Enable();
        }
        else
        {
            m_PilotControls.Cockpit.Disable();
        }
    }

    public void SetManualControls(bool _enabled)
    {
        if (_enabled)
        {
            m_PilotControls.Manual.Enable();
        }
        else
        {
            m_PilotControls.Manual.Disable();
        }
    }

    public void SetMovement2DControls(bool _enabled)
    {
        if (_enabled)
        {
            m_EngineerControls.Movement2D.Enable();
        }
        else
        {
            m_EngineerControls.Movement2D.Disable();
        }
    }
    public void MeteoriteDamage()
    {
        CauseShipDamage(0, false);
    }
    public void CauseShipDamage(float _startDelay, bool _recall = false)
    {
        StartCoroutine(DamageShip(_startDelay, _recall));
    }
    private void CauseMeteorShower()
    {
        OnMeteorShower?.Invoke();
        Invoke("CauseMeteorShower", 35 + 20 * m_ChaosGradient);
    }
    private IEnumerator DamageShip(float _delay = 0, bool _recall = false)
    {
        yield return new WaitForSeconds(_delay);
        bool selected = false;
        var rnd = new System.Random();
        RoomNode selection = null;
        int i = 0;
        while (!selected && i < 10)
        {
            List<RoomNode> copies = m_Rooms.OrderBy(item => rnd.Next()).ToList<RoomNode>();
            print(copies.Count);
            foreach (RoomNode r in copies)
            {
                if (r.m_DamageState != DamageState.FATAL)
                {
                    selected = true;
                    selection = r;
                }
            }
            i++;
        }
        if (selection) selection.TakeDamage(1);
        if (_recall)
        {
            StartCoroutine(DamageShip(80 - (20 * m_ChaosGradient), _recall));
        }
        yield break;
    }
}