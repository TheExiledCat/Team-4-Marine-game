using System;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleComponent : MonoBehaviour
{
    public static event Action OnInitialization;
    public virtual void Initiate()
    {
        OnInitialization?.Invoke();
    }
}