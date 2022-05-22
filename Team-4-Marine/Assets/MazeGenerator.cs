using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField]
    private Vector2Int m_StartPosition, m_Target;

    public Tilemap m_TileMapToGenerate;
    private List<Cell> m_Cells;

    public void Generate()
    {
        m_Cells = new List<Cell>();
        print("Click");
        m_TileMapToGenerate.CompressBounds();
        BoundsInt bounds = m_TileMapToGenerate.cellBounds;
        TileBase[] tiles = m_TileMapToGenerate.GetTilesBlock(bounds);
        for (int y = bounds.size.y - 1; y >= 0; y--)
        {
            for (int x = 0; x < bounds.size.x; x++)
            {
                TileBase t = tiles[x + y * bounds.size.x];
                if (t)
                {
                    Vector2 pos = new Vector2(x, bounds.size.y - y - 1);
                    //print(tiles[i].name);
                    Cell c = new Cell(); ;
                    c.m_Position = pos;

                    foreach (char letter in t.name)
                    {
                        switch (letter)
                        {
                            case 'B':
                                c.m_WallDown = true;
                                break;

                            case 'T':
                                c.m_WallUp = true;
                                break;

                            case 'L':
                                c.m_WallLeft = true;
                                break;

                            case 'R':
                                c.m_WallRight = true;
                                break;
                        }
                    }

                    m_Cells.Add(c);
                }
            }
        }
        CreateMap();
    }

    private void CreateMap()
    {
        print(m_Cells.Count);
        string json = JsonUtility.ToJson(new Maze(m_Cells, (Vector2Int)m_TileMapToGenerate.cellBounds.size, m_StartPosition, m_Target));
        System.IO.File.WriteAllText(System.IO.Path.Combine(Application.dataPath + "/Mazes", "Maze.txt"), json);
    }
}