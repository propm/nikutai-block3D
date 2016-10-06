using UnityEngine;
using System.Collections;

public class LeftPaddle : MonoBehaviour
{

    public float paddleSpeed = 1f;

    void Update()
    {
        //等速アニメーション
        if (Input.GetKey("right")) this.transform.position += new Vector3(paddleSpeed, 0, 0);

        if (Input.GetKey("left")) this.transform.position -= new Vector3(paddleSpeed, 0, 0);

        if (transform.position.x >= 23)
        {
            this.transform.position = new Vector3(23, 1, -25f);
        }
        else if (transform.position.x <= -27)
        {
            this.transform.position = new Vector3(-27, 1, -25f);
        }

    }
}