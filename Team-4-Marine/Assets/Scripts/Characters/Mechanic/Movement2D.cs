using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement2D : MonoBehaviour
{
    private Engineer.Movement2DActions m_2DControls;
    private InputAction m_Move;
    private Rigidbody2D m_Rb;

    [SerializeField]
    private Vector2 m_Delta;

    [SerializeField]
    private float
    m_Speed,
    m_MaxSpeed,
    m_Acceleration,
    m_Spacing;

    [SerializeField]
    private Vector2 m_MoveDirection = Vector2.zero;

    private void Start()
    {
        m_2DControls = GameManager.GM.m_EngineerControls.Movement2D;
        m_Move = m_2DControls.Move;
        m_Rb = GetComponent<Rigidbody2D>();
        m_Rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        m_Rb.gravityScale = 0;
    }

    private void Move(float _topSpeed, float _decaySpeed)
    {
        m_MoveDirection = m_Move.ReadValue<Vector2>();

        if (Mathf.Abs(m_Delta.x) <= _decaySpeed)
        {
            m_Delta.x += m_Acceleration * m_MoveDirection.x;
        }
        if (Mathf.Abs(m_Delta.y) <= _decaySpeed)
        {
            m_Delta.y += m_Acceleration * m_MoveDirection.y;
        }

        Decay();
        m_Delta.x = Mathf.Clamp(m_Delta.x, -_topSpeed, _topSpeed);
        m_Delta.y = Mathf.Clamp(m_Delta.y, -_topSpeed, _topSpeed);
    }

    private void Update()
    {
        m_MoveDirection = m_Move.ReadValue<Vector2>();
        if (!m_2DControls.Sprint.IsPressed())
        {
            Move(m_MaxSpeed, m_Speed);
        }

        if (m_2DControls.Sprint.IsPressed())
        {
            Move(m_MaxSpeed, m_MaxSpeed);
        }
        m_Rb.velocity = m_Delta * Time.deltaTime;
    }

    private void Decay()
    {
        if (m_MoveDirection.x == 0 && m_Rb.velocity.x != 0 || !m_2DControls.Sprint.IsPressed() && Mathf.Abs(m_Delta.x) > m_Speed)
        {
            m_Delta.x += m_Acceleration * -Mathf.Sign(m_Rb.velocity.x);
            m_Delta.x = Mathf.Abs(m_Delta.x) < m_Acceleration ? 0 : m_Delta.x;
        }

        if (m_MoveDirection.y == 0 && m_Rb.velocity.y != 0 || !m_2DControls.Sprint.IsPressed() && Mathf.Abs(m_Delta.y) > m_Speed)
        {
            m_Delta.y += m_Acceleration * -Mathf.Sign(m_Rb.velocity.y);
            m_Delta.y = Mathf.Abs(m_Delta.y) < m_Acceleration ? 0 : m_Delta.y;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position + (new Vector3(m_Delta.normalized.x, m_Delta.normalized.y, 0) * Mathf.Abs(m_Delta.magnitude) / m_MaxSpeed), 0.05f);
    }
}