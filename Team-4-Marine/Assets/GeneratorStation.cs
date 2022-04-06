using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorStation : RepairStation
{
    [SerializeField] private GameObject m_PhysicalModel;

    private bool m_RedIsOn;
    private bool m_YellowIsOn;
    private void Start()
    {
        RandomizeStation();
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
            if (!CheckForFailure())
            {
                print("win");
                m_Fixed = true;
                OnComplete?.Invoke();
            }
        }
        else
        {
            if (CheckForFailure())
            {
                print("broken");
                m_Fixed = false;
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
                m_Indicators[1].SetIndicator(m_YellowIsOn);
                break;
            case 2:
                m_Indicators[2].SetIndicator(m_RedIsOn);
                break;
        }
    }
    public override bool CheckForFailure()
    {
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
                    if (!m_Switches[0].GetState())
                    {
                        return false;//win
                    }
                }
            }
        }
        else
        {
            //1B
        }

        return true;
    }
    protected override void RandomizeStation()
    {
        base.RandomizeStation();
        m_RedIsOn = new System.Random().NextDouble() > 0.5f ? true : false;
        m_YellowIsOn = new System.Random().NextDouble() > 0.2f ? true : false;
    }
    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
    }
}