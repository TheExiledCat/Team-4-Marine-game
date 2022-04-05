using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : Interactable
{
    [SerializeField] protected List<float> m_Positions = new List<float>();
    [SerializeField]
    protected int m_CurrentPosition;

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
    public override void Randomize()
    {
        base.Randomize();
        System.Random random = new System.Random();
        m_CurrentPosition = random.Next(m_Positions.Count);
    }
}