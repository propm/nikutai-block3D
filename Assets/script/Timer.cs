using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{    
    public static int time = 100;
    public Ball ball;
    bool started = true;

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
            GetComponent<Text>().text = time.ToString();
            yield return new WaitForSeconds(1);
            time -= 1;
        }
        //制限時間が0になったらスコア画面に遷移
        SceneManager.LoadScene("ScoreScene");

    }
    public static int getTime() { return time; }
}