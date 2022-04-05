using System;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleComponent : MonoBehaviour
{
    public static event Action OnRanomize;
    public virtual void Randomize()
    {
        OnRanomize?.Invoke();
    }
}