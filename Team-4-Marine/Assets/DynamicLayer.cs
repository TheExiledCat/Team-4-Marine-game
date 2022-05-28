using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class DynamicLayer : MonoBehaviour
{
    [SerializeField]
    private float m_YBorder;
    public SpriteRenderer m_SR;
    private int m_StartingLayer;
    private void Start()
    {
        m_SR = GetComponent<SpriteRenderer>();
        m_StartingLayer = m_SR.sortingLayerID;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position + Vector3.up * m_YBorder, new Vector3(GetComponent<SpriteRenderer>().bounds.size.x, 0));
    }
    public float GetBorder()
    {
        return m_YBorder;
    }
    public void SetOrder(int _order)
    {
        m_SR.sortingLayerID = _order;
    }
}