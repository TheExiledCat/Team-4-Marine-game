using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CellGroup
{
    public List<Cell> m_Cells;
    public Vector2 m_Size;

    public CellGroup(List<Cell> _Cells, Vector2 _size)
    {
        m_Cells = new List<Cell>();
        m_Cells = _Cells;
        m_Size = _size;
    }
}