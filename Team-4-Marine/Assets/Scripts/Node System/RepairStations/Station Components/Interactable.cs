using System;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : PuzzleComponent
{
    public static event Action OnInteract;

    public static event Action OnSecondaryinteract;

    public virtual void Interact()
    {
        OnInteract?.Invoke();
    }

    public virtual void SecondaryInteract()
    {
        OnSecondaryinteract?.Invoke();
    }
}