using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{

    public float ballInitialVelocity = 600f;


    private Rigidbody rb;
    private bool ballInPlay;
	private GameObject ball;

    void Start()
    {
		ball = GameObject.Find ("Ball");
        rb = GetComponent<Rigidbody>();

    }

    void Update()
    {
		ballInPlay = MainGameData.GetBallInPlay();
        if (Input.GetButtonDown("Fire1") && ballInPlay == false)
        {
            transform.parent = null;
			MainGameData.SetBallInPlay (true);
            rb.isKinematic = false;
			rb.AddForce(new Vector3(ballInitialVelocity*2, 0, ballInitialVelocity*(-2)));
        }

    }

	void onCollisionEnter(){
		Vector3 ballvel = transform.gameObject.GetComponent<Rigidbody>().velocity;
		ballvel = ballvel.normalized * 15;

		if (Mathf.Abs (ballvel.y) < 5) {
			ballvel.z *= 5;
		}
		if (Mathf.Abs (ballvel.x) < 5) {
			ballvel.x *= 5;
		}
		transform.gameObject.GetComponent<Rigidbody>().velocity = ballvel;
	}

}