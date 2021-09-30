using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float ballInitialVelocity = 900f;
    private Rigidbody rb;
    private bool ballInPlay;
    // Awake is called before Start, when the object becomes enabled.
    void Awake()
    {
        rb=GetComponent<Rigidbody>();
    }
  

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && ballInPlay == false)
        {
            transform.parent = null;
            ballInPlay = true;
            rb.isKinematic = false;
            rb.AddForce(new Vector3(ballInitialVelocity,ballInitialVelocity,0));
        }
    }
}
