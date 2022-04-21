using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class NodeMonitor : MonoBehaviour
{
    [SerializeField]
    private List<Tilemap> m_TileMapsToShow = new List<Tilemap>();

    [SerializeField]
    private Transform m_Origin;

    [SerializeField]
    private float m_MaxWidth;

    [SerializeField]
    private List<Sprite> m_Sprites = new List<Sprite>();

    [SerializeField]
    private List<MapNode> m_Nodes = new List<MapNode>();

    private Dictionary<string, RoomNode> m_RoomNodes = new Dictionary<string, RoomNode>();
    private Dictionary<string, Image> m_Icons = new Dictionary<string, Image>();//string is the name of the node and then returns the icon on it

    private void Start()
    {
        CreateTileMaps();
        GetAllNodes();
        CreateNodes<RoomNode>();
        CreateNodes<UtilityNode>();
    }

    private void CreateTileMaps() // instantiates the level tiles as a canvas element
    {
        int i = 0;
        foreach (Tilemap t in m_TileMapsToShow)
        {
            BoundsInt tileBounds = t.cellBounds;
            TileBase[] block = t.GetTilesBlock(tileBounds);
            print(tileBounds);

            for (int y = 0; y < tileBounds.size.y; y++)
            {
                for (int x = 0; x < tileBounds.size.x; x++)
                {
                    TileBase tile = block[x + y * tileBounds.size.x];
                    print(tile != null);
                    if (tile != null)
                    {
                        GameObject canvasCell = new GameObject();

                        Image img = canvasCell.AddComponent<Image>();
                        canvasCell.transform.SetParent(m_Origin);
                        img.sprite = m_Sprites[i];
                        RectTransform trans = canvasCell.GetComponent<RectTransform>();
                        trans.anchoredPosition = (Vector2)TileToCanvas(t, new Vector2Int(x, y));

                        trans.sizeDelta = new Vector2(GetCellSize(t), GetCellSize(t));
                        trans.localScale = Vector3.one;
                        canvasCell.name = x + "," + y + " Tile";
                    }
                }
            }
        }
    }

    private void GetAllNodes()
    {
        MapNode[] allNodes = FindObjectsOfType<MapNode>();
        print(allNodes.Length);
        for (int i = 0; i < allNodes.Length; i++)
        {
            m_Nodes.Add(allNodes[i]);
            if (allNodes[i] is RoomNode)
            {
                m_RoomNodes.Add(allNodes[i].m_NodeName, allNodes[i] as RoomNode);
            }
        }
    }

    private void CreateNodes<T>()
    {
        foreach (MapNode m in m_Nodes)
        {
            if (m is T)
            {
                GameObject nodeObject = new GameObject();

                Image img = nodeObject.AddComponent<Image>();
                nodeObject.transform.SetParent(m_Origin);
                img.sprite = m.m_Icon;
                RectTransform trans = nodeObject.GetComponent<RectTransform>();
                trans.anchoredPosition = WorldToCanvas(m_TileMapsToShow[0], m.transform.position);

                trans.sizeDelta = new Vector2(GetCellSize(m_TileMapsToShow[0]), GetCellSize(m_TileMapsToShow[0]));
                trans.localScale = Vector3.one;
                nodeObject.name = m.m_NodeName;
                m_Icons.Add(m.m_NodeName, img);
            }
        }
    }

    private void FixedUpdate()
    {
        UpdateIcons();
    }

    private void UpdateIcons()
    {
        foreach (KeyValuePair<string, RoomNode> k in m_RoomNodes)
        {
            Image img = m_Icons[k.Key];
            DamageState ds = k.Value.m_DamageState;

            switch (ds)
            {
                case DamageState.CRITICAL:
                    img.color = Color.red;
                    break;

                case DamageState.DAMAGED:
                    img.color = new Color(255, 215, 0);
                    break;

                case DamageState.FULL:
                    img.color = Color.green;
                    break;
            }
        }
    }

    public Vector3 WorldToCanvas(Tilemap _map, Vector3 _pos)
    {
        Vector2 canvasPosition = (_pos - _map.cellBounds.min) * GetCellSize(_map);
        return canvasPosition;
    }

    public Vector3 TileToCanvas(Tilemap _map, Vector2Int _tilePos)
    {
        Vector2 canvasPosition = _map.GetCellCenterLocal(new Vector3Int(_tilePos.x, _tilePos.y, 0)) * (GetCellSize(_map));
        return canvasPosition;
    }

    public float GetCellSize(Tilemap _map)
    {
        float canvasCellSize = m_MaxWidth / _map.cellBounds.size.x;
        return canvasCellSize;
    }
}