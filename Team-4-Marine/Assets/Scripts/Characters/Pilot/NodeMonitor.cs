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
    private Dictionary<string, RectTransform> m_CustomIcons = new Dictionary<string, RectTransform>();
    private Vector2 m_Overlap;
    private float xWidth;
    private float m_CanvasTileSize;

    [SerializeField]
    private GameObject m_Player;

    [SerializeField]
    private Sprite m_PlayerSprite;

    private void Start()
    {
        CreateTileMaps();
        GetAllNodes();
        CreateNodes<RoomNode>();
        CreateNodes<UtilityNode>();
        if (m_Player != null)
            CreateCustomSprite(m_Player.transform.position, m_PlayerSprite, m_Player.gameObject.name);
    }

    private void FixedUpdate()
    {
        UpdateIcons();
        if (m_Player != null)
            UpdateCustomSpritePosition(m_Player.gameObject.name, m_Player.transform.position);
    }

    private void CreateTileMaps() // instantiates the level tiles as a canvas element
    {
        int i = 0;
        Vector2Int bounds = (Vector2Int)m_TileMapsToShow[0].cellBounds.min;
        m_Overlap.x = bounds.x;
        float max = m_TileMapsToShow[0].cellBounds.xMax;
        foreach (Tilemap t in m_TileMapsToShow)
        {
            t.CompressBounds();
            BoundsInt tileBounds = t.cellBounds;
            TileBase[] block = t.GetTilesBlock(tileBounds);
            if (tileBounds.xMin < m_Overlap.x) m_Overlap.x = tileBounds.xMin;
            if (tileBounds.yMin < m_Overlap.y) m_Overlap.y = tileBounds.yMin;
            if (tileBounds.xMax > max) max = tileBounds.xMax;
        }
        xWidth = max - m_Overlap.x;
        m_CanvasTileSize = m_MaxWidth / xWidth;
        foreach (Tilemap t in m_TileMapsToShow)
        {
            t.CompressBounds();
            BoundsInt tileBounds = t.cellBounds;
            TileBase[] block = t.GetTilesBlock(tileBounds);

            //if (tileBounds.yMin < m_Overlap.y) m_Overlap.y = tileBounds.yMin;
            for (int y = 0; y < tileBounds.size.y; y++)
            {
                for (int x = 0; x < tileBounds.size.x; x++)
                {
                    TileBase tile = block[x + y * tileBounds.size.x];
                    if (tile != null)
                    {
                        GameObject canvasCell = new GameObject();

                        Image img = canvasCell.AddComponent<Image>();
                        canvasCell.transform.SetParent(m_Origin);
                        img.sprite = m_Sprites[i];
                        RectTransform trans = canvasCell.GetComponent<RectTransform>();
                        trans.anchoredPosition = (Vector2)TileToCanvas(t, new Vector2Int(x, y));

                        trans.sizeDelta = new Vector2(m_CanvasTileSize, m_CanvasTileSize);
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
                trans.anchoredPosition = WorldToCanvas(m.transform.position);

                trans.sizeDelta = new Vector2(m_CanvasTileSize, m_CanvasTileSize);
                trans.localScale = Vector3.one;
                nodeObject.name = m.m_NodeName;
                m_Icons.Add(m.m_NodeName, img);
            }
        }
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

    public void CreateCustomSprite(Vector3 _pos, Sprite _icon, string _name)
    {
        GameObject nodeObject = new GameObject();

        Image img = nodeObject.AddComponent<Image>();
        nodeObject.transform.SetParent(m_Origin);
        img.sprite = _icon;
        RectTransform trans = nodeObject.GetComponent<RectTransform>();
        trans.anchoredPosition = WorldToCanvas(_pos);

        trans.sizeDelta = new Vector2(m_CanvasTileSize, m_CanvasTileSize);
        trans.localScale = Vector3.one;
        nodeObject.name = _name;
        m_CustomIcons.Add(_name, trans);
    }

    public void UpdateCustomSpritePosition(string _name, Vector3 _pos)
    {
        if (m_CustomIcons[_name] != null)
            m_CustomIcons[_name].anchoredPosition = WorldToCanvas(_pos);
    }

    public Vector3 WorldToCanvas(Vector3 _pos)
    {
        Vector2 canvasPosition = (_pos - (Vector3)m_Overlap) * m_CanvasTileSize;
        return canvasPosition;
    }

    public Vector3 TileToCanvas(Tilemap _map, Vector2Int _tilePos)
    {
        Vector2 canvasPosition = ((_map.GetCellCenterWorld((Vector3Int)_tilePos) + (Vector3.right * _map.cellBounds.xMin) - (Vector3.right * m_Overlap.x) - (Vector3.up * m_Overlap.y) + (Vector3.up * _map.cellBounds.y))) * m_CanvasTileSize;
        return canvasPosition;
    }
}