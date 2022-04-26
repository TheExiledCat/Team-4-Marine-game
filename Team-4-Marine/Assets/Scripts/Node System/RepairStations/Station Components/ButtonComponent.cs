using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonComponent : Interactable
{
    public UnityEvent m_Actions;

    public override void Interact()
    {
        base.Interact();
        m_Actions?.Invoke();
    }
}