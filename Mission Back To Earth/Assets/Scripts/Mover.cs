using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float mainThrust = 1000f;
    [SerializeField] float rotationThrust = 100f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProccesThrust();
        ProcessRotation();
    }
    void ProccesThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Pressed SPACE - Thrust");
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        }
    }
    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Pressed A - Rotating Left");
            ApplyRotation(-rotationThrust);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Pressed D - Rotating Right");
            ApplyRotation(rotationThrust);
        }
    }

    public void ApplyRotation(float rotationFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(-Vector3.forward * rotationFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
