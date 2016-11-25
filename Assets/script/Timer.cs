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
    int speedItem = Random.Range(20, 25+1);
    public GameObject SpeedUp;
    bool obMove;
    public GameObject particle;

    int[] i = new int[3] { 1,1,1};

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
            if(time == startTime-speedItem*i[0])
            {
                i[0]++;
                Vector3 particlePosition = new Vector3(Random.Range(-20, 21), 0.5f, 4);
                GameObject ob = (GameObject)Instantiate(SpeedUp, particlePosition, Quaternion.identity);
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