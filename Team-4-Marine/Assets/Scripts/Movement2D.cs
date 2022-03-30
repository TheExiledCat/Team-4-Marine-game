using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement2D : MonoBehaviour
{
    [SerializeField]
    public Rigidbody m_rb;

    [SerializeField]
    private Vector2 m_Delta;

    [SerializeField]
    private float
    m_Speed,
    m_maxSpeed,
    m_Acceleration,
    m_Spacing;


    private EngineerInputActions EngineerControls;

    [SerializeField]
    Vector2 moveDirection = Vector2.zero;
    private InputAction m_Move;

    private void Awake()
    {
        EngineerControls = new EngineerInputActions();
    }

    private void OnEnable()
    {
        m_Move = EngineerControls.Engineer.Move;

        EngineerControls.Engineer.Enable();
    }

    private void OnDisable()
    {
        m_Move.Disable();
        EngineerControls.Engineer.Disable();
    }

    private void Move(float _topSpeed,float _decaySpeed)
    {

        moveDirection = m_Move.ReadValue<Vector2>();

        if(Mathf.Abs(m_Delta.x)< _decaySpeed){
            m_Delta.x += m_Acceleration * moveDirection.x;
        }
        if (Mathf.Abs(m_Delta.y) < _decaySpeed)
        {
            m_Delta.y += m_Acceleration * moveDirection.y;
        }
        

        Decay();
        m_Delta.x = Mathf.Clamp(m_Delta.x, -_topSpeed, _topSpeed);
        m_Delta.y = Mathf.Clamp(m_Delta.y, -_topSpeed, _topSpeed);

        
    }

    void Update()
    {
        moveDirection = m_Move.ReadValue<Vector2>();
        if (!EngineerControls.Engineer.Sprint.IsPressed())
        {
            Move(m_maxSpeed,m_Speed);
        }
        
        if (EngineerControls.Engineer.Sprint.IsPressed())
        {
            Move(m_maxSpeed,m_maxSpeed);
        }
        m_rb.velocity = m_Delta * Time.deltaTime;

    }
    void Decay()
    {
        if (moveDirection.x == 0 && m_rb.velocity.x != 0 || !EngineerControls.Engineer.Sprint.IsPressed() && Mathf.Abs(m_Delta.x) > m_Speed)
        {
            m_Delta.x += m_Acceleration * -Mathf.Sign(m_rb.velocity.x);
            m_Delta.x = Mathf.Abs(m_Delta.x) < m_Acceleration ? 0 : m_Delta.x;
        }

        if (moveDirection.y == 0 && m_rb.velocity.y != 0 || !EngineerControls.Engineer.Sprint.IsPressed() && Mathf.Abs(m_Delta.y) > m_Speed)
        {
            m_Delta.y += m_Acceleration * -Mathf.Sign(m_rb.velocity.y);
            m_Delta.y = Mathf.Abs(m_Delta.y) < m_Acceleration ? 0 : m_Delta.y;
        }
    }
}




