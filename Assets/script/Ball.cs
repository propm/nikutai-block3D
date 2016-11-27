using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    public GameObject prefab;
    public GameObject feverParticle;
    public GameObject speedUpParticle;

    public float ballInitialVelocity = 600f;
    bool started = false;
    bool activegetter;
    public bool restart = true;
    public int count = 3;

    public Countdown countdown;
    public Paddle paddle;
    private Rigidbody rb;
    private bool ballInPlay;
    public AudioSource audio;

    float zSpeed = 30;
    float lagger = 6;

    float speedCounter = 0;
    bool fwaiting, swaiting = false;

    public Material smaterial;
    public Material nmaterial;

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

        //フィーバーのパーティクル処理
        if (MainGameData.GetisFever() && !fwaiting)
        {
            GameObject ob = (GameObject)Instantiate(feverParticle, transform.position, Quaternion.identity);
            StartCoroutine(Wait(fwaiting, ob, 0.02f, 1));
        }

        //スピードアップゲット時の処理
        if (MainGameData.SpeedUp && !swaiting)
        {
            speedCounter += Time.deltaTime;
            zSpeed = 45;
            lagger = 8;
            GetComponent<Renderer>().material = smaterial;
            GetComponent<Renderer>().material.SetColor("_TintColor", Color.red);
            GameObject ob = (GameObject)Instantiate(speedUpParticle, transform.position, Quaternion.identity);
            StartCoroutine(Wait(swaiting, ob, 0.02f, 2));
        }
        else
        {
            zSpeed = 30;
            lagger = 6;
        }
        if(speedCounter >= 10)
        {
            MainGameData.SpeedUp = false;
            speedCounter = 0;
            GetComponent<Renderer>().material = nmaterial;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        velocityCtrl();
        paddleCtrl(collision);
        if (collision.gameObject.tag == "Block")
        {
            audio.PlayOneShot(audio.clip);
        }
    }

    void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.tag == "Block")
        {
            audio.PlayOneShot(audio.clip);
        }
    }

    private void velocityCtrl()
    {

        if (started)       //ゲームがスタートされていたら
        {
            Vector3 v = rb.velocity;    // 速度を取得.
            
            if (-zSpeed < v.z && v.z <= 0)
            {                                           // Zの速度が-30～0なら.
                v.z = -zSpeed;                           // Zの値を -30.0f に.
            }
            else if (0 < v.z && v.z < zSpeed)
            {                                           // Zの速度が0～30なら
                v.z = zSpeed;                            // Zの値を +30.0f に.
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
            v.x = lag * lagger;
            if((lag <= 2)&&(lag >= -2)) { v.z = zSpeed*1.1f; }
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
    IEnumerator Wait(bool waiting ,GameObject ob, float per, float dest)
    {
        waiting = true;
        yield return new WaitForSeconds(per);
        waiting = false;
        yield return new WaitForSeconds(dest);
        Destroy(ob);

    }
    public bool Getactive() { return activegetter; }
}