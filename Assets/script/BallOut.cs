using UnityEngine;
using System.Collections;

public class BallOut : MonoBehaviour
{
    GameObject ball;
    public Ball ball2;
    // Use this for initialization
    void Start()
    {
        ball = GameObject.Find("Ball");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            ball.transform.position = new Vector3(0f, 1f, 0f);
            ball.transform.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
            MainGameData.SetBallInPlay(false);
            ball2.GetComponent<Ball>().restart = false;
        }
    }
}
