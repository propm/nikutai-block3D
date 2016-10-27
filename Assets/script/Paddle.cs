using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class Paddle : MonoBehaviour
{
    public float paddleSpeed = 1f;
    
	private Vector3 playerPos = new Vector3(0, 1f, -25f);

    void Start()
    {
    }

    void Update()
	{
        //Socket.Update();
        //Debug.Log(Socket.Value.ToString());
		//Vector3 mPosition = Input.mousePosition;
		float xPos = transform.position.x + (Input.GetAxis("Horizontal") * paddleSpeed);
		//float xPos = mPosition.x;
		playerPos = new Vector3(Mathf.Clamp(xPos, -25f, 25f), 1f, -25f);
		transform.position = playerPos;

	}

    void OnApplicationQuit()
    {
        //Socket.End();
    }
}