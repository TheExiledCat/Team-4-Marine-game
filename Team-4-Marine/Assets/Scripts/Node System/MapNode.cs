using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapNode : MonoBehaviour
{
    [SerializeField]
    protected string m_NodeName;
    [SerializeField]
    protected Sprite m_Icon;
    private void OnDrawGizmos()
    {
        Gizmos.DrawIcon(transform.position, "MapNode");
    }
}