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
    protected virtual void RandomizeStation()
    {
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