using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    public float myTimeScale = 1.0f;
    public GameObject target;
    public float launchForce = 10f;
    Rigidbody rb;
    private void Start()
    {
        Time.timeScale = myTimeScale;
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FiringSolution fire = new FiringSolution();
            Nullable<Vector3> aimVector = fire.CalculateFiringSolution(transform.position, target.transform.position, launchForce, Physics.gravity);
            if(aimVector.HasValue)
            {
                rb.AddForce(aimVector.Value.normalized * launchForce, ForceMode.VelocityChange);
            }
        }
    }
}
