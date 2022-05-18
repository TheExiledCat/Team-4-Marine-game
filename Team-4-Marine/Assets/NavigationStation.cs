using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationStation : RepairStation
{
    // Start is called before the first frame update

    private Maze m_MazeA, m_MazeB;

    [SerializeField]
    private Vector2Int m_CurrentPosition;

    private Vector2Int m_PreviousPosition;
    private Maze m_ChosenMaze;
    private Indicator[] m_Lights;

    [SerializeField]
    private GameObject m_LightParent;

    // Update is called once per frame
    public override void Start()
    {
        m_Buttons[0].m_Actions.AddListener(MoveLeft);
        m_Buttons[1].m_Actions.AddListener(MoveRight);
        m_Buttons[2].m_Actions.AddListener(MoveDown);
        m_Buttons[3].m_Actions.AddListener(MoveUp);
        m_ChosenMaze = JsonUtility.FromJson<Maze>(System.IO.File.ReadAllText(System.IO.Path.Combine(Application.dataPath + "/Mazes", "Maze.txt")));
        print(m_ChosenMaze.m_Width);
        base.Start();
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

        return false;
    }

    private int PositionToIndicator(Vector2Int _position)
    {
        int target = _position.x + _position.y * (m_ChosenMaze.m_Width + 2);
        return target;
    }

    private void ClampPosition()
    {
        m_CurrentPosition = new Vector2Int(Mathf.Clamp(m_CurrentPosition.x, 0, m_ChosenMaze.m_Width), Mathf.Clamp(m_CurrentPosition.y, 0, m_ChosenMaze.m_Height));

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