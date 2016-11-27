using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{    
    public static int time = 150;
    public static int startTime = 150;
    public Ball ball;
    bool started = true;
    public Text finishText;
    public AudioSource audio;
    public AudioSource bgm;
    bool b = true;
    int speedItem = Random.Range(startTime-30, startTime -20);
    int ballItem = Random.Range(startTime - 40, startTime - 30);
    int feverItem = Random.Range(startTime - 50, startTime - 10);
    public GameObject SpeedUp;
    public GameObject BigBall;
    public GameObject PlusFever;
    bool obMove;
    public GameObject particle;

    Vector3 itemPosition = new Vector3(Random.Range(-20, 21), 0.5f, 4);

    void Start()
    {

    }

    void Update()
    {
      if (ball.Getactive() == false&&started)
      {
            StartCoroutine("timer");
            started = false;
     }
    }

    IEnumerator timer()
    {
        while (time > -1)
        {
            if(time == speedItem)
            {
                speedItem = Random.Range(time-30, time-20);
                GameObject ob = (GameObject)Instantiate(SpeedUp, itemPosition, Quaternion.identity);
            }
            if (time == ballItem)
            {
                ballItem = Random.Range(time - 30, time - 20);
                GameObject ob = (GameObject)Instantiate(BigBall, itemPosition, Quaternion.identity);
            }
            if(time == feverItem)
            {
                feverItem = Random.Range(time - 50, time - 10);
                GameObject ob = (GameObject)Instantiate(PlusFever, itemPosition, Quaternion.identity);
            }
            if (time == 60)
            {
                GetComponent<Text>().color = Color.yellow;
            }
            if(time == 10) {
                GetComponent<Text>().color = Color.red;
            }
            GetComponent<Text>().text = time.ToString();
            yield return new WaitForSeconds(1);
            time -= 1;
        }
        if(b) {
            StartCoroutine("Clear");
            b = false;
        }

    }
    IEnumerator Clear()
    {
        audio.PlayOneShot(audio.clip);
        Time.timeScale = 0.001f;
        finishText.text = "FINISH!";
        yield return new WaitForSeconds(0.002f);
        SceneManager.LoadScene("ScoreScene");
    }

    public static int getTime() { return time; }
}