using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Switch : Interactable
{
    private bool m_SwitchedOn;

    [SerializeField]
    private float m_TopAngle, m_BotAngle;

    public void SetState(bool _state)
    {
        m_SwitchedOn = _state;
        transform.localEulerAngles = new Vector3(0, 0, m_SwitchedOn ? m_TopAngle : m_BotAngle);
    }

    public void Toggle()
    {
        m_SwitchedOn = !m_SwitchedOn;
        transform.localEulerAngles = new Vector3(0, 0, m_SwitchedOn ? m_TopAngle : m_BotAngle);
    }
    public override void Randomize()
    {
        base.Randomize();
        SetState((Random.Range(0f, 1f) < 0.5f) ? true : false);
    }
    public override void Interact()
    {
        base.Interact();
        Toggle();
    }
}