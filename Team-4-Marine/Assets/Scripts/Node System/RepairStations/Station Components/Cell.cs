using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Cell
{
    [HideInInspector]
    public Vector2 m_Position;
    public bool m_WallLeft = false;
    public bool m_WallRight = false;
    public bool m_WallUp = false;
    public bool m_WallDown = false;
}