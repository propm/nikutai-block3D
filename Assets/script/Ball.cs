using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{

    public float ballInitialVelocity = 600f;


    private Rigidbody rb;
    private bool ballInPlay;
	GameObject ball;

    void Start()
    {
		ball = GameObject.Find ("Ball");
        rb = GetComponent<Rigidbody>();

    }

    void Update()
    {
		if (Input.GetButtonDown("Fire1") && MainGameData.GetBallInPlay() == false)
        {
            transform.parent = null;
			MainGameData.SetBallInPlay (true);
            rb.isKinematic = false;
			rb.AddForce(new Vector3(ballInitialVelocity*2, 0, ballInitialVelocity*(-2)));
        }

    }

	void onCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "Out") {
			ball.transform.position = new Vector3 (0f, 1f, 0f);
			ball.transform.gameObject.GetComponent<Rigidbody> ().velocity = new Vector3 (0f, 0f, 0f);
			MainGameData.SetBallInPlay (false);
		} else {
			Vector3 ballvel = transform.gameObject.GetComponent<Rigidbody> ().velocity;
			ballvel = ballvel.normalized * 15;

			if (Mathf.Abs (ballvel.y) < 5) {
				ballvel.z *= 5;
			}
			if (Mathf.Abs (ballvel.x) < 5) {
				ballvel.x *= 5;
			}
			transform.gameObject.GetComponent<Rigidbody> ().velocity = ballvel;
		}

	}

}