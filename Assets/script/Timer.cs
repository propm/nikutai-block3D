using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public int time = 60;
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

        if (ball.Getactive()) {
            StopCoroutine("timer");
            started = true;
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
    }
}