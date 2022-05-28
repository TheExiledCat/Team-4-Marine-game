using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerManager : MonoBehaviour
{
    [SerializeField] private float m_YBorder;
    [SerializeField] private LayerMask m_Props;
    [SerializeField] private int m_AbovePlayer;
    [SerializeField] private int m_BelowPlayer;
    private Collider2D[] cols;
    private void Update()
    {
        cols = Physics2D.OverlapCapsuleAll(transform.position, Vector3.one * 10, CapsuleDirection2D.Horizontal, 0, m_Props);
        for (int i = 0; i < cols.Length; i++)
        {
            DynamicLayer d = cols[i].GetComponent<DynamicLayer>();
            if (d != null)
            {
                if (transform.position.y + m_YBorder > d.transform.position.y + d.GetBorder())
                {
                    d.SetOrder(m_AbovePlayer);
                }
                else
                {
                    d.SetOrder(m_BelowPlayer);
                }
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position + Vector3.up * m_YBorder, Vector3.right * 2);
    }
}