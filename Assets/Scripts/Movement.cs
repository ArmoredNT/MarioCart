using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float accelerationStrength = 5;
    [SerializeField] private float steeringStrength = 5;
    
    private float steeringInput;
    private float accelerationInput;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        steeringInput = Input.GetAxis("Horizontal");
        accelerationInput = Input.GetAxis("Vertical");
        
        AddForce();
        AddSteering();
    }

    void AddForce()
    {
        Vector3 force;

        force = transform.forward * (accelerationInput * accelerationStrength);
        rb.AddForce(force, ForceMode.Force);
    }

    void AddSteering()
    {
        //transform.rotation = Quaternion.Euler(0, (transform.rotation.y * Mathf.Rad2Deg), 0);
        print(transform.rotation.eulerAngles.y);
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + (steeringInput * steeringStrength), 0);
    }
}
