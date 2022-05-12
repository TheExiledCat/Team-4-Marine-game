using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    private Vector3 increaseValues = new Vector3(0, 0, 20f);

    void Update()
    {
        transform.position -= increaseValues * Time.deltaTime;

        if (transform.position.z <= 6)
        {
            Destroy(gameObject);
        }
    }


}
