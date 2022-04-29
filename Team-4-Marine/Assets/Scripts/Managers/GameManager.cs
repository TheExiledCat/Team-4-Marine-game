using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GM = null;
    public Pilot m_PilotControls;
    public Engineer m_EngineerControls;
    private List<RoomNode> m_Rooms = new List<RoomNode>();
    public float m_ChaosGradient = 0.5f;
    private float m_Progress = 0;

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
    }

    private void Update()
    {
        if (m_EngineerControls.Interactions.ReturnInteract.WasPressedThisFrame())
        {
            print("Damaging");
            CauseShipDamage();
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

    public void CauseShipDamage(bool _recall = false)
    {
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
            Invoke("CauseShipDamage", 120 - (60 * m_ChaosGradient));
        }
    }
}