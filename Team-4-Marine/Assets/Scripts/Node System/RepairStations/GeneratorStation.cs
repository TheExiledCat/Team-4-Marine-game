using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorStation : RepairStation
{
    [SerializeField] private GameObject m_PhysicalModel;
    [SerializeField]
    private bool m_RedIsOn, m_YellowIsOn;
    private void Start()
    {
        InitiatePuzzle();
    }
    public override void Open()
    {
        m_PhysicalModel.gameObject.SetActive(true);
    }

    public override void Close()
    {
        m_PhysicalModel.gameObject.SetActive(false);
    }
    protected override void Update()
    {
        base.Update();
        SetIndicators();

        if (!m_Fixed)
        {
            if (CheckForMechanic()) GetComponent<SpriteRenderer>().color = Color.cyan;
            else GetComponent<SpriteRenderer>().color = Color.yellow;
            if (!CheckForFailure())
            {
                print("win");
                m_Fixed = true;
                GetComponent<SpriteRenderer>().color = Color.green;
                OnComplete?.Invoke();
            }
        }
        else
        {
            if (CheckForFailure())
            {
                print("broken");
                m_Fixed = false;
                GetComponent<SpriteRenderer>().color = Color.yellow;
            }
        }
    }
    protected override void LateUpdate()
    {
        base.LateUpdate();
    }
    private void SetIndicators()
    {
        foreach (Indicator i in m_Indicators)
        {
            i.SetIndicator(false);
        }
        switch (m_Handles[0].GetPosition())
        {
            case 1:
                print("Yellow On");
                m_Indicators[1].SetIndicator(m_YellowIsOn);
                break;
            case 2:
                print("Red On");
                m_Indicators[2].SetIndicator(m_RedIsOn);
                break;
        }
    }
    public override bool CheckForFailure() // Puzzle win condition, hardcoded
    {
        print("Checking");
        if (m_Displays[0].GetCrosses() >= 3)
        {
            //1A
            if (m_Handles[0].GetPosition() == 2)//Handle to red
            {
                if (m_RedIsOn) // red turns on
                {
                    if (m_Rotaries[0].GetPosition() == 1 &&
                    m_Switches[1].GetState())//knob to 1200 and right switch on
                    {
                        return false;//win
                    }
                }
                else //red stays off
                {
                    if (m_Switches[0].GetState())
                    {
                        return false;//win
                    }
                }
            }
        }
        else
        {
            //1B
            if (m_Handles[0].GetPosition() == 1)//Handle to yellow
            {
                if (m_Displays[0].GetCrosses() >= 2) // 2 crosses
                {
                    //2B
                    if (m_Rotaries[0].GetPosition() == 0 && m_Switches[0].GetState() && m_Switches[1].GetState())//knob on 1600 and both switches on
                    {
                        return false;//win
                    }
                }
                else //1 cross
                {
                    if (m_Rotaries[0].GetPosition() == 2 && m_Switches[0].GetState())//knob to 800 and left switch to on
                    {
                        return false;//win
                    }
                }
            }
        }

        return true;//not done yet
    }
    protected override void InitiatePuzzle()
    {
        base.InitiatePuzzle();
        GetComponent<SpriteRenderer>().color = m_Fixed ? Color.green : Color.yellow;
        m_RedIsOn = Random.Range(0f, 1f) > 0.5f ? true : false;
        m_YellowIsOn = Random.Range(0f, 1f) > 0.5f ? true : false;
    }
    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
    }
}