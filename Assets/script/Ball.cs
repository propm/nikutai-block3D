﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;


[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{

    public float ballInitialVelocity = 600f;
    public bool started = false;
    public bool restart = true;


    public Countdown countdown;
    private Rigidbody rb;
    private bool ballInPlay;

    void Start()
    {   
        rb = GetComponent<Rigidbody>();
        StartCoroutine("Countdown");    //カウントダウンコルーチン開始
    }

    void Update()
    {
        if(!restart) {        //ボールが動いていなかったら再びカウントダウンからのスタート
            StartCoroutine("Countdown");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        velocityCtrl();
    }

    private void velocityCtrl()
    {

        if (started)       //ゲームがスタートされていたら
        {
            Vector3 v = rb.velocity;    // 速度を取得.

            if (-25.0f < v.x && v.x < 0.0f)
            {                                           // Xの速度が-25~0なら.
                v.x = -25.0f;                           // Xの値を -25.0f に.
            }
            else if (0.0f <= v.x && v.x < 25.0f)
            {                                           // Xの速度が0～25なら.
                v.x = 25.0f;                            // Xの値を +25.0f に.
            }

            if (-30.0f < v.z && v.z <= 0.0f)
            {                                           // Zの速度が-30～0なら.
                v.z = -30.0f;                           // Zの値を -30.0f に.
            }
            else if (0.0f < v.z && v.z < 30.0f)
            {                                           // Zの速度が0～30なら
                v.z = 30.0f;                            // Zの値を +20.0f に.
            }

            rb.velocity = v;    // 値を反映.
        }
    }

    IEnumerator Countdown() {
        restart = true;

        countdown.GetComponent<Countdown>().text = 3;
        countdown.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);             //一秒待つ

        countdown.GetComponent<Countdown>().text = 2;   //カウントダウンテキストを2にする
        yield return new WaitForSeconds(1);             

        countdown.GetComponent<Countdown>().text = 1;  //カウントダウンテキストを1にする
        yield return new WaitForSeconds(1);

        countdown.gameObject.SetActive(false);        //カウントダウンテキストを非表示にする    

        //ゲームスタート
        transform.parent = null;
        MainGameData.SetBallInPlay(true);
        rb.isKinematic = false;
        rb.AddForce(new Vector3(0, 0, ballInitialVelocity * (-1.5f)));
        started = true;
    }
}