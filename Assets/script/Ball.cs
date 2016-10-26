using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    public GameObject prefab;

    public float ballInitialVelocity = 600f;
    bool started = false;
    bool activegetter;
    public bool restart = true;
    public int count = 3;

    public Countdown countdown;
    public Paddle paddle;
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
        if (MainGameData.GetisFever() == true)
        {
            Vector3 particle = this.transform.position;
            Instantiate(prefab, particle, Quaternion.identity);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        velocityCtrl();
        paddleCtrl(collision);

        if (collision.gameObject.CompareTag("Particle") == false)
        {
            Vector3 particle = this.transform.position;
            Instantiate(prefab, particle, Quaternion.identity);
        }
    }

    private void velocityCtrl()
    {

        if (started)       //ゲームがスタートされていたら
        {
            Vector3 v = rb.velocity;    // 速度を取得.
            
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

    //パドルにボールが当たったら
    void paddleCtrl(Collision collision) {

        Vector3 v = rb.velocity;    // 速度を取得.

        //パドルの端に当たるほど反射角度を急にする
        if (collision.transform.name == "Paddle")
        {
            float lag = transform.position.x - paddle.transform.position.x;
            v.x = lag * 7;
            if((lag <= 2)&&(lag >= -2)) { v.z = 37f; }
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