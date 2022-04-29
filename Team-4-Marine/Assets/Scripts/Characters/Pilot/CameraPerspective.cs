using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CameraPerspective
{
    [SerializeField]
    public Vector3 m_CameraRotations;
    [SerializeField]
    public Bounds m_PerspectiveBounds;
}
