using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorStation : RepairStation
{
    [SerializeField] private GameObject m_PhysicalModel;

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

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
    }
}