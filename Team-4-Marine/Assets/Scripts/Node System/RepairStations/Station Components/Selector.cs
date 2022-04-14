using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : Interactable
{
    [SerializeField] protected List<float> m_Positions = new List<float>();

    [SerializeField]
    protected int m_CurrentPosition;

    [SerializeField]
    private Vector3 m_Axis;

    private Vector3 m_OriginalRotation;

    public override void Interact()
    {
        base.Interact();
        m_CurrentPosition++;
        m_CurrentPosition = Mathf.Clamp(m_CurrentPosition, 0, m_Positions.Count - 1);
    }

    public override void SecondaryInteract()
    {
        base.SecondaryInteract();
        m_CurrentPosition--;
        m_CurrentPosition = Mathf.Clamp(m_CurrentPosition, 0, m_Positions.Count - 1);
    }

    public override void Initiate()
    {
        base.Initiate();
        System.Random random = new System.Random();
        m_CurrentPosition = random.Next(m_Positions.Count);
        m_OriginalRotation = transform.localEulerAngles;
    }

    protected virtual void Update()
    {
        UpdateRotation();
    }

    protected void UpdateRotation()
    {
        Vector3 origin = m_OriginalRotation;
        origin = m_OriginalRotation - Vector3.Scale(m_Axis, m_OriginalRotation);
        print(origin);
        origin = origin + m_Axis * m_Positions[m_CurrentPosition];
        print(origin);
        if (m_Positions.Count > 0)
            transform.localRotation = Quaternion.Euler(origin);
    }

    public int GetPosition()
    {
        return m_CurrentPosition;
    }

    protected override void Randomize()
    {
        base.Randomize();
        m_CurrentPosition = Mathf.FloorToInt(Random.Range(0f, m_Positions.Count));
    }
}