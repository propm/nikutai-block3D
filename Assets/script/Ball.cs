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
		if (collision.gameObject.tag == "Respawn") {
			ball.transform.position = new Vector3 (0f, 1f, 0f);
			ball.transform.gameObject.GetComponent<Rigidbody> ().velocity = new Vector3 (0f, 0f, 0f);
			MainGameData.SetBallInPlay (false);
		} 
		velocityCtrl ();

	}

	private void velocityCtrl(){
		Vector3 v = rb.velocity;	// 速度を取得.

		if(-3.0f < v.x && v.x <= 0.0f){			// Xの速度が-3～0なら.
			v.x = -3.0f;							// Xの値を -3.0f に.
		}else if(0.0f < v.x && v.x < 3.0f ){	// Xの速度が0～3なら).
			v.x =  3.0f;							// Xの値を +3.0f に.
		}

		if(-10.0f < v.y &&  v.y <= 0.0f){		// Yの速度が-10～0なら.
			v.y = -10.0f;							// Yの値を -10.0f に.
		}else if(0.0f < v.y && v.y < 10.0f){	// Yの速度が0～10なら).
			v.y = 10.0f;							// Yの値を +10.0f に.
		}

		rb.velocity = v;	// 値を反映.
	}

}