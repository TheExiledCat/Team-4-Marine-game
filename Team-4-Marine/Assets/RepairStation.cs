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

    public static Action OnComplete;

    protected virtual void RandomizeStation()
    {
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
    }
}