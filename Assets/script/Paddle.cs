using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour
{

    public float paddleSpeed = 1f;


    private Vector3 playerPos = new Vector3(0, 1f, -9.5f);

    void Update()
    {
        float xPos = transform.position.x + (Input.GetAxis("Horizontal") * paddleSpeed);
        playerPos = new Vector3(Mathf.Clamp(xPos, -15f, 15f), 1f, -9.5f);
        transform.position = playerPos;

    }
}