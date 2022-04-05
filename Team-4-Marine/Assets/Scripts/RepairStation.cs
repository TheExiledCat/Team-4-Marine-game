using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class RepairStation : MonoBehaviour
{
    [SerializeField]
    private string m_StationName;

    [SerializeField]
    private bool m_Fixed;

    [SerializeField]
    private Rect m_Hitbox;

    [SerializeField]
    private LayerMask m_PlayerMask;

    public static Action OnComplete;
    public static Action OnFail;
    public static Action OnOpen;
    public static Action OnClose;
    private bool m_Opened;

    [SerializeField] private List<Switch> m_Switches = new List<Switch>();
    [SerializeField] private List<Handle> m_Handles = new List<Handle>();
    [SerializeField] private List<RotaryKnob> m_Rotaries = new List<RotaryKnob>();
    [SerializeField] private List<Indicator> m_Indicators = new List<Indicator>();
    [SerializeField] private List<StationDisplay> m_Displays = new List<StationDisplay>();
    protected virtual void RandomizeStation()
    {
        foreach (Switch s in m_Switches) s.Randomize();
        foreach (Handle h in m_Handles) h.Randomize();
        foreach (RotaryKnob r in m_Rotaries) r.Randomize();
        //foreach (Indicator i in m_Switches) i.Randomize();
        foreach (StationDisplay sd in m_Displays) sd.Randomize();
        if (!CheckForFailure()) RandomizeStation(); else return;
    }

    private void LateUpdate()
    {
        CheckForMechanic();
    }

    public virtual void Open()
    {
        print("Opening");
        m_Opened = true;
        OnOpen?.Invoke();
    }

    public virtual void Close()
    {
        if (m_Opened == false)
        {
            print("Closing");
            m_Opened = false;
            OnClose?.Invoke();
        }
    }
    public virtual bool CheckForFailure()
    {
        return true;
    }
    public bool CheckForMechanic()
    {
        Collider2D[] cols = Physics2D.OverlapBoxAll(transform.position + (Vector3)m_Hitbox.position, m_Hitbox.size, 0, m_PlayerMask);
        if (cols.Length > 0)
        {
            cols[0].GetComponent<MechanicScript>().SetStation(this);
            print("SetStation");
            return true;
        }
        return false;
    }

    public bool IsFixed()
    {
        return m_Fixed;
    }

    protected virtual void OnDrawGizmos()
    {
        if (m_Fixed)
        {
            Gizmos.color = Color.gray;
            Gizmos.DrawIcon(transform.position, "d_Favorite@2x");
        }
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position + (Vector3)m_Hitbox.position, m_Hitbox.size);
    }
}