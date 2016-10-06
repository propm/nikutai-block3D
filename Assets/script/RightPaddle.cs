using UnityEngine;
using System.Collections;

public class RightPaddle : MonoBehaviour
{

    public float paddleSpeed = 1f;

    void Update()
    {
        //←→で移動できるようにする
        if(Input.GetKey("right"))this.transform.position += new Vector3(paddleSpeed, 0, 0);

        if (Input.GetKey("left")) this.transform.position -= new Vector3(paddleSpeed, 0, 0);

        //paddleが壁からはみ出ないようにする
        if (transform.position.x >= 27)
        {
            this.transform.position = new Vector3(27, 1, -25.06f);
        }
        else if (transform.position.x <= -23)
        {
            this.transform.position = new Vector3(-23, 1, -25.06f);
        }

    }
}