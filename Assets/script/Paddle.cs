using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class Paddle : MonoBehaviour
{
    public float paddleSpeed = 1f;
    private double rate;
    private float position;
	private Vector3 playerPos = new Vector3(0, 1f, -25f);
    void Start()
    {
    }

    void Update()
	{
        rate = (Socket.Data + 128.0)/255.0;
        float xPos = (float)((50 * rate + (-25))*(-1));
        Debug.Log(rate);

		Vector3 mPosition = Input.mousePosition;
		//float xPos = transform.position.x + (Input.GetAxis("Horizontal") * paddleSpeed);
		playerPos = new Vector3(Mathf.Clamp(xPos, -25f, 25f), 1f, -25f);
		transform.position = playerPos;

	}

    void OnApplicationQuit()
    {
        Socket.IsEnd = true;
    }
}