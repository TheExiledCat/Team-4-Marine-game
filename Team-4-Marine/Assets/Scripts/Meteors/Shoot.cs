using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    private Camera m_PilotCam;

    public Transform m_ShootPosition;
    public Transform m_GunPosition;
    [SerializeField]
    private GameObject LazerPrefab;

    [SerializeField]
    Vector2 move;

    Pilot.CockpitActions m_CockpitControls;
    // Start is called before the first frame update
    void Start()
    {
        m_CockpitControls = GameManager.GM.m_PilotControls.Cockpit;
    }

    // Update is called once per frame
    void Update()
    {
        move = m_CockpitControls.ShootingMovement.ReadValue<Vector2>();

        if (m_CockpitControls.Shooting.WasPressedThisFrame())
        {
            Fire();
        }

        m_ShootPosition.position += (Vector3)move;



        //Vector3 forward = m_ShootPosition.transform.TransformDirection(Vector3.forward) * 500;
        Debug.DrawRay(m_PilotCam.transform.position, m_ShootPosition.transform.position-m_PilotCam.transform.position, Color.green);
    }

    private void Fire()
    {
        Debug.Log("iAmShooting");
        RaycastHit hit;
        if(Physics.Raycast(m_PilotCam.transform.position, m_ShootPosition.transform.position-m_PilotCam.transform.position, out hit))
        {
            print(hit.collider.gameObject.name);
           Lazer l =Instantiate(LazerPrefab, transform).GetComponent<Lazer>();
            l.ShootBeam(m_GunPosition.position, m_ShootPosition.position, 0.2f);
            Debug.Log(hit.transform.name);
            Destroy(hit.collider.gameObject);
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
