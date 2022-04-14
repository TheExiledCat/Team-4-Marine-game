using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class OpenCloseDoors : MonoBehaviour
{
    [SerializeField]
    private bool m_DoorsClosed = false;


    [SerializeField]
    private TilemapCollider2D m_Doors;

    private void Start()
    {
        m_DoorsClosed = false;
        m_Doors = GetComponent<TilemapCollider2D>();
    }

    private void Update()
    {
        if (m_DoorsClosed)
        {
            Debug.Log("deuren zijn open");
            m_Doors.enabled = false;
        }

        if (!m_DoorsClosed)
        {
            Debug.Log("deuren zijn dicht");
            m_Doors.enabled = true;
        }
    }
}
