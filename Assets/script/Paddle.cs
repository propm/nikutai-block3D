using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour
{

	public float paddleSpeed = 1f;


	private Vector3 playerPos = new Vector3(0, 1f, -25f);

	void Update()
	{
		float xPos = transform.position.x + (Input.GetAxis("Horizontal") * paddleSpeed);
		playerPos = new Vector3(Mathf.Clamp(xPos, -25f, 25f), 1f, -25f);
		transform.position = playerPos;

	}
}