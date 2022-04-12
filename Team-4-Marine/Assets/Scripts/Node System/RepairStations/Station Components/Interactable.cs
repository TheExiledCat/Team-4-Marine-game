using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]//, typeof(Rigidbody))]
public class Interactable : PuzzleComponent
{
    public static event Action OnInteract;

    public static event Action OnSecondaryinteract;

    public override void Initiate()
    {
        base.Initiate();
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
}