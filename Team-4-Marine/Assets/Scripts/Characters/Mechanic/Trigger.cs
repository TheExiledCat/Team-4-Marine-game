using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]

public class Trigger : MonoBehaviour
{

    public UnityEvent OnEnter;
    public UnityEvent OnExit;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnEnter?.Invoke();
        Invoke("DissableText", 6.0f);

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        OnExit?.Invoke();
        DissableText();
    }

    private void DissableText()
    {
        GetComponent<BoxCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
