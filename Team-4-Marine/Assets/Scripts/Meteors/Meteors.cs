using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Meteors : MonoBehaviour
{
    public GameObject m_MeteorPrefab;
    public static event Action m_OnDamage;
    private float X_Pos, Y_Pos, Z_Pos;




    private bool m_Spawner = false;

   
    public void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            StartSpawner();
        }

    }

    IEnumerator MeteorSpawner(int _amount, float _delay)
    {
        for (int i = 0; i < _amount; i++)
        {
            Y_Pos = UnityEngine.Random.Range(-8, 12);
            X_Pos = UnityEngine.Random.Range(-10, 10);
            Z_Pos = 250;

           Meteor m=  Instantiate(m_MeteorPrefab, new Vector3(X_Pos, Y_Pos, Z_Pos), Quaternion.identity).GetComponent<Meteor>();
            m.Subscribe(Damage);

            yield return new WaitForSeconds(_delay);
        }
    }

    public void StartSpawner()
    {
        StartCoroutine(MeteorSpawner(UnityEngine.Random.Range(5,15),UnityEngine.Random.Range(0.1f, 1f)));
    }
    public void Damage()
    {
        m_OnDamage?.Invoke();
        print("damage taken");
    }
}

