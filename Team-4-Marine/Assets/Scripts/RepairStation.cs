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

    protected virtual void RandomizeStation()
    {
    }
    private void LateUpdate()
    {
        CheckForMechanic();
    }
    private void CheckForMechanic()
    {
        Collider2D[] cols = Physics2D.OverlapBoxAll(transform.position + (Vector3)m_Hitbox.position, m_Hitbox.size, 0, m_PlayerMask);
        if (cols.Length > 0)
        {
            cols[0].GetComponent<MechanicScript>().SetStation(this);
            print("SetStation");
        }
    }
    public bool IsFixed()
    {
        return m_Fixed;
    }

    private void OnDrawGizmos()
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