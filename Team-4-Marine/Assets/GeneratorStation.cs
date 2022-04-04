using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorStation : RepairStation
{
    [SerializeField] private Canvas m_TestCanvas;
    public override void Open()
    {
        m_TestCanvas.gameObject.SetActive(true);
    }
    public override void Close()
    {
        m_TestCanvas.gameObject.SetActive(false);
    }
    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
    }
}