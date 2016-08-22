using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{

    public float ballInitialVelocity = 600f;


    private Rigidbody rb;
    private bool ballInPlay;

    void Awake()
    {

        rb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && ballInPlay == false)
        {
            transform.parent = null;
            ballInPlay = true;
            rb.isKinematic = false;
			rb.AddForce(new Vector3(ballInitialVelocity*2, 0, ballInitialVelocity*(-2)));
        }

    }

}