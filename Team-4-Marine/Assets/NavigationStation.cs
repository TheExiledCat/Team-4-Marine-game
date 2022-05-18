using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationStation : RepairStation
{
    // Start is called before the first frame update
    [SerializeField]
    private Maze m_MazeA, m_MazeB;
    private Vector2Int m_CurrentPosition;
    private Maze m_ChosenMaze;
    // Update is called once per frame
    public override void Start()
    {
        m_Buttons[0].m_Actions.AddListener(MoveLeft);
        m_Buttons[1].m_Actions.AddListener(MoveRight);
        m_Buttons[2].m_Actions.AddListener(MoveUp);
        m_Buttons[3].m_Actions.AddListener(MoveDown);

        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }
    private void MoveLeft()
    {
        if (!CheckWalls(Vector2Int.left))
            m_CurrentPosition += Vector2Int.left;
    }
    private void MoveRight()
    {
        if (!CheckWalls(Vector2Int.right))
            m_CurrentPosition += Vector2Int.right;
    }
    private void MoveUp()
    {
        if (!CheckWalls(Vector2Int.up))
            m_CurrentPosition += Vector2Int.up;
    }
    private void MoveDown()
    {
        if (!CheckWalls(Vector2Int.down))
            m_CurrentPosition += Vector2Int.down;
    }
    private bool CheckWalls(Vector2Int _dir)
    {
        Vector2Int start = m_CurrentPosition;
        Vector2Int target = start + _dir;

        return false;
    }
}