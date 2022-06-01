using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationStation : RepairStation
{
    // Start is called before the first frame update
    [SerializeField]
    private Maze m_MazeA, m_MazeB;

    [SerializeField]
    private Vector2Int m_CurrentPosition;

    private Vector2Int m_PreviousPosition;
    private Maze m_ChosenMaze;

    [SerializeField]
    private Indicator[] m_Lights;

    [SerializeField]
    private GameObject m_LightParent;

    private void Awake()
    {
        m_MazeA = JsonUtility.FromJson<Maze>(System.IO.File.ReadAllText(System.IO.Path.Combine(Application.dataPath + "/Mazes", "MazeA.txt")));
        m_MazeB = JsonUtility.FromJson<Maze>(System.IO.File.ReadAllText(System.IO.Path.Combine(Application.dataPath + "/Mazes", "MazeB.txt")));

        m_ChosenMaze = m_MazeA;
    }

    // Update is called once per frame
    public override void Start()
    {
        base.Start();
        m_Buttons[0].m_Actions.AddListener(MoveLeft);
        m_Buttons[1].m_Actions.AddListener(MoveRight);
        m_Buttons[2].m_Actions.AddListener(MoveDown);
        m_Buttons[3].m_Actions.AddListener(MoveUp);
    }

    public override void InitiatePuzzle()
    {
        base.InitiatePuzzle();
        print("initiating");
        switch (m_Displays[0].GetCrosses())
        {
            case 1:
                m_ChosenMaze = m_MazeA;
                break;

            case float n when (n > 1):
                m_ChosenMaze = m_MazeB;
                break;
        }
        print(m_ChosenMaze.m_Width);
        print(m_Lights.Length);
        m_Lights = m_LightParent.GetComponentsInChildren<Indicator>();
        for (int i = 0; i < m_Lights.Length; i++)
        {
            m_Lights[i].Initiate();
        }
        Indicate();
        //StartCoroutine(Test());
        m_CurrentPosition = Vector2Int.zero;
    }

    protected override void Update()
    {
        base.Update();
    }

    private void MoveLeft()
    {
        if (!CheckWalls(Vector2Int.left))
            m_CurrentPosition += Vector2Int.left;
        ClampPosition();
    }

    private void MoveRight()
    {
        if (!CheckWalls(Vector2Int.right))
            m_CurrentPosition += Vector2Int.right;
        ClampPosition();
    }

    private void MoveUp()
    {
        if (!CheckWalls(Vector2Int.up))
            m_CurrentPosition += Vector2Int.up;
        ClampPosition();
    }

    private void MoveDown()
    {
        if (!CheckWalls(Vector2Int.down))
            m_CurrentPosition += Vector2Int.down;
        ClampPosition();
    }

    private bool CheckWalls(Vector2Int _dir)
    {
        m_PreviousPosition = m_CurrentPosition;
        Vector2Int start = m_CurrentPosition;
        Vector2Int target = start + _dir;
        Cell currentCell = null;
        try
        {
            currentCell = m_ChosenMaze.m_Cells[PositionToIndicator(start)];
        }
        catch (System.Exception)
        {
            Debug.Log("Error");
        }
        print(currentCell);
        Cell targetCell = null;
        bool wallFound = false;
        try
        {
            targetCell = m_ChosenMaze.m_Cells[PositionToIndicator(target)];
        }
        catch (System.Exception)
        {
            Debug.Log("Border Reached");
            wallFound = true;
        }
        if (wallFound == false)
        {
            switch (_dir.x)
            {
                case -1://left
                    if (currentCell.m_WallLeft || targetCell.m_WallRight) wallFound = true;
                    break;

                case 1://right
                    if (currentCell.m_WallRight || targetCell.m_WallLeft) wallFound = true;
                    break;
            }
            switch (_dir.y)
            {
                case -1://up
                    if (currentCell.m_WallUp || targetCell.m_WallDown) wallFound = true;
                    break;

                case 1://down
                    if (currentCell.m_WallDown || targetCell.m_WallUp) wallFound = true;
                    break;
            }
        }
        if (wallFound) TakeDamage();
        print("Wall: " + wallFound);
        return wallFound;
    }

    public override void CheckWinCondition()
    {
        base.CheckWinCondition();
    }

    public override bool CheckForFailure()
    {
        if (m_CurrentPosition == m_ChosenMaze.m_EndPosition)
        {
            return false;
        }
        return true;
    }

    private int PositionToIndicator(Vector2Int _position)
    {
        int target = _position.x + _position.y * (m_ChosenMaze.m_Width);
        return target;
    }

    private void ClampPosition()
    {
        m_CurrentPosition = new Vector2Int(Mathf.Clamp(m_CurrentPosition.x, 0, m_ChosenMaze.m_Width - 1), Mathf.Clamp(m_CurrentPosition.y, 0, m_ChosenMaze.m_Height - 1));

        Indicate();
    }

    private void Indicate()
    {
        print(PositionToIndicator(m_CurrentPosition));
        m_Lights[PositionToIndicator(m_PreviousPosition)].SetIndicator(false);
        m_Lights[PositionToIndicator(m_CurrentPosition)].SetIndicator(true, Color.green);
    }

    private IEnumerator Test()
    {
        for (int i = 0; i < m_Lights.Length; i++)
        {
            m_Lights[i].SetIndicator(true);
            yield return new WaitForSecondsRealtime(1);
        }
        yield break;
    }
}