using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrusterNode : UtilityNode
{
    private float m_Increment = 60 * 60 * 10 * 2; //60 fps
    protected override void Start()
    {
        base.Start();
    }
    private void FixedUpdate()
    {
        if (m_Activated)
        {
            GameManager.GM.m_Progress += 1 / m_Increment;
        }
    }
    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
    }
}