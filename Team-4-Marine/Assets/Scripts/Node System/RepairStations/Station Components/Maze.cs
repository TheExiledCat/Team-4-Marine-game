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
}