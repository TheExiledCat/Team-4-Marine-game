using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class OpenCloseDoors : MonoBehaviour
{
    [SerializeField]
    private bool m_DoorsClosed = true;

    [SerializeField]
    private TilemapCollider2D m_Doors;

    private void Start()
    {
        m_Doors = GetComponent<TilemapCollider2D>();
    }

    private void Update()
    {
        if (m_DoorsClosed)
        {
            Debug.Log("deuren zijn open");
            m_Doors.enabled = false;
            //m_DoorsClosed = false;
        }

        if (!m_DoorsClosed)
        {
            Debug.Log("deuren zijn dicht");
            m_Doors.enabled = true;
            //m_DoorsClosed = true;
        }
    }
}
