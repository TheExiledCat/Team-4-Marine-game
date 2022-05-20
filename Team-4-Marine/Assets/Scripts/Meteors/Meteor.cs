using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Meteor : MonoBehaviour
{
    public  event Action m_OnDestroy;
    private Vector3 increaseValues = new Vector3(0, 0, 20f);

    void Update()
    {
        
        transform.position -= increaseValues * Time.deltaTime;

        if (transform.position.z <= 6)
        {
            m_OnDestroy?.Invoke();
            m_OnDestroy = null;
            Destroy(gameObject);
            
        }
    }
    public void Subscribe(Action _Callback)
    {
        m_OnDestroy += _Callback;
    }


}
