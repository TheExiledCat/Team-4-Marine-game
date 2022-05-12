using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStation : RepairStation
{
    private List<ToggleButton> m_Gears = new List<ToggleButton>();
    private bool m_IsA;
    private WeaponDisplay m_Display;
    public override void Start()
    {
        base.Start();
    }
    public override void CheckWinCondition()
    {
        base.CheckWinCondition();
    }

    protected override void LateUpdate()
    {
        base.LateUpdate();
    }
    protected override void Update()
    {
        base.Update();
        if (m_Display)
            m_Display.SetNone();
        CheckForStatus();
    }
    private void CheckForStatus()
    {
        if (m_Handles[0].GetPosition() == 1 && m_Handles[1].GetPosition() == 1)//both handles down
        {
            m_Display.SetA();
        }
        if (m_Handles[0].GetPosition() == 1 && m_Handles[1].GetPosition() == 0 && m_Gears[2].Get())
        {
            m_Display.SetB();
        }
    }
    protected override void InitiatePuzzle()
    {
        base.InitiatePuzzle();
        foreach (ButtonComponent b in m_Buttons)
        {
            m_Gears.Add(b as ToggleButton);
        }

        if (m_Displays[0].GetCrosses() <= 2)
        {
            m_IsA = true;
        }
        else
        {
            m_IsA = false;
        }
        m_Display = m_Displays[0] as WeaponDisplay;
    }
    public override bool CheckForFailure() // Puzzle win condition, hardcoded
    {
        print("Checking");
        if (m_Display && AmmoCheck()) return false;
        return true;//not done yet
    }
    private bool AmmoCheck()
    {
        switch (m_Display.GetAmmo())
        {
            case int n when (n > 0 && n <= 10):
                if (m_Gears[1].Get())
                {
                    foreach (ToggleButton t in m_Gears)
                    {
                        if (t != m_Gears[1] && t.Get()) return false;
                    }
                    return true;
                }
                break;
            case int n when (n >= 11 && n <= 35):
                if (m_Gears[2].Get())
                {
                    foreach (ToggleButton t in m_Gears)
                    {
                        if (t != m_Gears[2] && t.Get()) return false;
                    }
                    if (m_Handles[1].GetPosition() != 0)
                    {
                        return false;
                    }
                    return true;
                }
                break;
            case int n when (n >= 36 && n <= 65):
                if (m_Gears[0].Get() && m_Gears[3].Get())
                {
                    foreach (ToggleButton t in m_Gears)
                    {
                        if (t != m_Gears[0] && t != m_Gears[3] && t.Get()) return false;
                    }
                    return true;
                }
                break;
            case int n when (n >= 66 && n <= 83):
                if (m_Gears[3].Get() && m_Handles[0].GetPosition() == 0)
                {
                    foreach (ToggleButton t in m_Gears)
                    {
                        if (t != m_Gears[3] && t.Get()) return false;
                    }
                    return true;
                }
                break;
            case int n when (n >= 84 && n <= 100):

                foreach (ToggleButton t in m_Gears)
                {
                    if (!t.Get()) return false;
                }
                return true;
        }
        return false;
    }
}