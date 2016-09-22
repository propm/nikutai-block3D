using UnityEngine;
using UnityEngine.UI;
using System.Collections;


[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{

    public float ballInitialVelocity = 600f;
    bool started = false;
    bool activegetter;
    public bool restart = true;
    public int count = 3;

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
        if (!restart)
        {        //ボールが動いていなかったら再びカウントダウンからのスタート
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

    IEnumerator Countdown()
    {
        restart = true;

        countdown.GetComponent<Countdown>().text = count;
        countdown.gameObject.SetActive(true);           //カウントダウンテキストを表示する
        activegetter = true;

        for (int i = 1; i <= count; i++)
        {
            yield return new WaitForSeconds(1);             //一秒待つ
            countdown.GetComponent<Countdown>().text = count - i;
        }

        countdown.gameObject.SetActive(false);        //カウントダウンテキストを非表示にする    
        activegetter = false;

        //ゲームスタート
        transform.parent = null;
        MainGameData.SetBallInPlay(true);
        rb.isKinematic = false;
        rb.AddForce(new Vector3(0, 0, ballInitialVelocity * (-1.5f)));
        started = true;
    }
    public bool Getactive() { return activegetter; }
}