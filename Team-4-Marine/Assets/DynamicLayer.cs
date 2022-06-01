using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class DynamicLayer : MonoBehaviour
{
    [SerializeField]
    private float m_YBorder;
    [HideInInspector]
    public SpriteRenderer m_SR;
    private void Start()
    {
        m_SR = GetComponent<SpriteRenderer>();
        gameObject.layer = LayerMask.NameToLayer("Props");
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
        print(SortingLayer.IsValid(_order));
        m_SR.sortingLayerID = _order;
    }
}