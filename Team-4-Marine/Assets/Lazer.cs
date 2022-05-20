using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    private LineRenderer m_LR;

    public void ShootBeam(Vector3 _Start, Vector3 _End, float _Duration)
    {
        m_LR = GetComponent<LineRenderer>();
        m_LR.SetPosition(0, _Start);
        m_LR.SetPosition(1, _End);
        Destroy(gameObject, _Duration);
    }
}
