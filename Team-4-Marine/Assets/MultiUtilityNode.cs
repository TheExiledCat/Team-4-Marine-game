using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MultiUtilityNode : UtilityNode
{
    [SerializeField]
    private List<Vector2> m_NodesPositions = new List<Vector2>();

    [SerializeField]
    private Sprite m_MultiIcon;

    [SerializeField]
    private List<UtilityNode> m_Nodes = new List<UtilityNode>();

    [SerializeField] private bool m_UsingTileMap;
    [SerializeField] private Tilemap m_TilemapUsed;

    // Start is called before the first frame update
    private void Start()
    {
        if (!m_UsingTileMap)
        {
            foreach (Vector2 v in m_NodesPositions)
            {
                m_Nodes.Add(new GameObject().AddComponent<UtilityNode>());
                UtilityNode u = m_Nodes[m_Nodes.Count - 1];
                u.transform.position = v;
                u.m_NodeName = m_NodeName + m_Nodes.Count;
                u.m_Icon = m_MultiIcon;
            }
        }
        else
        {
            Grid grid = m_TilemapUsed.transform.parent.GetComponent<Grid>();
            BoundsInt tileBounds = m_TilemapUsed.cellBounds;
            for (int y = 0; y < tileBounds.y - 1; y++)
            {
                for (int x = 0; x < tileBounds.x - 1; x++)
                {
                    TileBase tile = m_TilemapUsed.GetTile(new Vector3Int(x, y, 0));
                    if (tile != null)
                    {
                        Vector3 pos = grid.CellToWorld(new Vector3Int(x, y, 0));
                        m_Nodes.Add(new GameObject().AddComponent<UtilityNode>());
                        UtilityNode u = m_Nodes[m_Nodes.Count - 1];
                        u.transform.position = pos;
                        u.m_NodeName = m_NodeName + m_Nodes.Count;
                        u.m_Icon = m_MultiIcon;
                    }
                }
            }
        }
    }

    private void Update()
    {
        SetUtilityStatus();
    }

    private void SetUtilityStatus()
    {
        foreach (UtilityNode u in m_Nodes)
        {
            u.SetEnabled(m_Activated);
        }
    }

    private void OnDrawGizmos()
    {
        foreach (Vector2 v in m_NodesPositions)
        {
            if (v != null)
                Gizmos.DrawIcon(v, "UtilityNode");
        }
    }
}