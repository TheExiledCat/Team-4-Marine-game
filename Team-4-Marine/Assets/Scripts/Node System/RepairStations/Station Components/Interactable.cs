using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]//, typeof(Rigidbody))]
public class Interactable : PuzzleComponent
{
    public static event Action OnInteract;

    public static event Action OnSecondaryinteract;

    [SerializeField]
    protected bool m_IsRandom;

    public override void Initiate()
    {
        base.Initiate();
        if (m_IsRandom) Randomize();
    }

    public virtual void Interact()
    {
        OnInteract?.Invoke();
        print("Interacted with " + name);
    }

    public virtual void SecondaryInteract()
    {
        OnSecondaryinteract?.Invoke();
        print("Secondary Interacted with " + name);
    }

    protected virtual void Randomize()
    {
    }
}