using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public GameObject m_ShootPosition;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown("l"))
        {
            Debug.Log("L");
            Fire();
        }
        if (m_ShootPosition.transform.position.x >= -4)
        {
            if (Input.GetKey("a"))
            {
                m_ShootPosition.transform.position -= new Vector3(1, 0, 0) * 2 * Time.deltaTime;
                Debug.Log(m_ShootPosition.transform.position);
            }
        }
        if (m_ShootPosition.transform.position.y <= 4)
        {
            if (Input.GetKey("d"))
            {
                m_ShootPosition.transform.position += new Vector3(1, 0, 0) * 2 * Time.deltaTime;
                Debug.Log(m_ShootPosition.transform.position);
            }
        }
        if (m_ShootPosition.transform.position.y >= -2)
        {
            if (Input.GetKey("s"))
            {
                m_ShootPosition.transform.position -= new Vector3(0, 1, 0) * 2 * Time.deltaTime;
                Debug.Log(m_ShootPosition.transform.position);
            }
        }
        if(m_ShootPosition.transform.position.y <= 4)
        {
            if (Input.GetKey("w"))
            {
                m_ShootPosition.transform.position += new Vector3(0, 1, 0) * 2 * Time.deltaTime;
                Debug.Log(m_ShootPosition.transform.position);
            }
        }


        Vector3 forward = m_ShootPosition.transform.TransformDirection(Vector3.forward) * 100;
        Debug.DrawRay(m_ShootPosition.transform.position, forward, Color.green);
    }

    private void Fire()
    {
        RaycastHit hit;
        if(Physics.Raycast(m_ShootPosition.transform.position, m_ShootPosition.transform.forward, out hit))
        {
            Debug.Log(hit.transform.name);
        }
    }

    //if (Input.GetMouseButtonDown(0)) {
    //        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

    //RaycastHit2D hit = Physics2D.Raycast(, Vector2.zero);
    //        if (hit.collider != null) {
    //            Debug.Log(hit.collider.gameObject.name);
    //            hit.collider.attachedRigidbody.AddForce(Vector2.up);
    //        }
}
