using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Maze
{
    [HideInInspector]
    public int m_Width = 8, m_Height = 10;

    [SerializeField]
    public List<Cell> m_Cells;

    public Vector2Int m_StartPosition;

    public Maze(List<Cell> _cells, Vector2Int _Size)
    {
        m_Cells = new List<Cell>();
        m_Cells = _cells;
        m_Width = _Size.x;
        m_Height = _Size.y;
    }
}