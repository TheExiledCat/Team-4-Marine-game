using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteors : MonoBehaviour
{
    public GameObject m_MeteorPrefab;

    private float X_Pos, Y_Pos, Z_Pos;

    private GameObject m_Meteor;


    public void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            StartSpawner();
        }

    }

    IEnumerator MeteorSpawner()
    {
        for (int i = 0; i < 10; i++)
        {
            Y_Pos = Random.Range(-8, 12);
            X_Pos = Random.Range(-10, 10);
            Z_Pos = 250;

            m_Meteor = Instantiate(m_MeteorPrefab, new Vector3(X_Pos, Y_Pos, Z_Pos), Quaternion.identity);

            yield return new WaitForSeconds(Random.Range(0.1f, 1f));
        }
    }

    public void StartSpawner()
    {
        StartCoroutine("MeteorSpawner");
    }


}

