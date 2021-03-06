using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MapNode : MonoBehaviour
{
    public string m_NodeName;

    public Sprite m_Icon;

    protected virtual void Start()
    {
        GetComponent<Rigidbody2D>().isKinematic = true;
    }

    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawIcon(transform.position, "MapNode");
    }
}