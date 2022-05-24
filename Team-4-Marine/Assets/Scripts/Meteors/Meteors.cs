using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Meteors : MonoBehaviour
{

    [SerializeField]
    private List<Sprite> m_Sprites;

    public GameObject m_MeteorPrefab;
    public static event Action m_OnDamage;
    private float X_Pos, Y_Pos, Z_Pos;
   
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
            Y_Pos = UnityEngine.Random.Range(-12, 12);
            X_Pos = UnityEngine.Random.Range(-15, 15);
            Z_Pos = 400;

           Meteor m =  Instantiate(m_MeteorPrefab, new Vector3(X_Pos, Y_Pos, Z_Pos), Quaternion.identity).GetComponent<Meteor>();
            m.GetComponent<SpriteRenderer>().sprite = m_Sprites[UnityEngine.Random.Range(0, Mathf.FloorToInt(m_Sprites.Count))];
            m.Initialize();
            m.Subscribe(Damage);

            yield return new WaitForSeconds(_delay);
        }
    }

    public void StartSpawner()
    {
        StartCoroutine(MeteorSpawner(UnityEngine.Random.Range(10,20),UnityEngine.Random.Range(0.2f, 1f)));
    }
    public void Damage()
    {
        m_OnDamage?.Invoke();
        print("damage taken");
    }
}

