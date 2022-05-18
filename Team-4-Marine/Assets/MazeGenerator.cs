using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MazeGenerator : MonoBehaviour
{
    public Tilemap m_TileMapToGenerate;
    private List<Cell> m_Cells;

    public void Generate()
    {
        m_Cells = new List<Cell>();
        print("Click");
        m_TileMapToGenerate.CompressBounds();
        BoundsInt bounds = m_TileMapToGenerate.cellBounds;
        TileBase[] tiles = m_TileMapToGenerate.GetTilesBlock(bounds);
        for (int i = 0; i < tiles.Length - 1; i++)
        {
            if (tiles[i])
            {
                Vector2 pos = new Vector2(i % bounds.size.x % bounds.size.x, bounds.size.y - (i / bounds.size.x / bounds.size.x));
                print(tiles[i].name);
                Cell c = new Cell(); ;
                c.m_Position = pos;

                foreach (char letter in tiles[i].name)
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
        CreateMap();
    }

    private void CreateMap()
    {
        print(m_Cells.Count);
        string json = JsonUtility.ToJson(new Maze(m_Cells, (Vector2Int)m_TileMapToGenerate.cellBounds.size));
        System.IO.File.WriteAllText(System.IO.Path.Combine(Application.dataPath + "/Mazes", "Maze.txt"), json);
    }
}