using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPush : MonoBehaviour
{
    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    void Update()
    {
        //excution of Attck of push 
        if (Input.GetKeyDown(KeyCode.Mouse0) == true)
        {
            GetComponent<Animator>().SetTrigger("BPush");
        }
    }
}
