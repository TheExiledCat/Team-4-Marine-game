using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Switch : Interactable
{
    [SerializeField]
    private bool m_SwitchedOn;

    [SerializeField]
    private float m_TopAngle, m_BotAngle;

    [SerializeField]
    private Indicator m_Light;

    public bool GetState()
    {
        return m_SwitchedOn;
    }

    public void SetState(bool _state)
    {
        m_SwitchedOn = _state;
        UpdateRotation();
        SetLight();
    }

    public void Toggle()
    {
        m_SwitchedOn = !m_SwitchedOn;
        UpdateRotation();
        SetLight();
    }

    private void SetLight()
    {
        m_Light.SetIndicator(m_SwitchedOn);
    }

    private void UpdateRotation()
    {
        transform.localEulerAngles = new Vector3(0, 0, m_SwitchedOn ? m_TopAngle : m_BotAngle);
    }

    public override void Initiate()
    {
        base.Initiate();
        //if (!m_IsConstant)
        //{
        //    base.Initiate();
        //    SetState((Random.Range(0f, 1f) < 0.5f) ? true : false);
        //}
        m_Light.Initiate();
        SetState(false);
    }

    public override void Interact()
    {
        base.Interact();
        Toggle();
    }

    protected override void Randomize()
    {
        base.Randomize();
        m_SwitchedOn = Random.Range(0f, 1f) > 0.5f ? true : false;
    }
}