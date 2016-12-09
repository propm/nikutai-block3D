using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Button : MonoBehaviour {
    public int number;
    public Text loading;
    // ボタンをクリックした時の処理
    public void ButtonPush()
    {
        loading.text = "loading...";
        Application.LoadLevel("scene1");
        Application.LoadLevel("ScoreScene");
        MainGameData.SetScore(0);
        MainGameData.SetFever(0);
        MainGameData.isFever = false;
        MainGameData.BigBall = false;
        MainGameData.SpeedUp = false;
        Timer.time = Timer.startTime;
        Time.timeScale = 1;
        Ball.speedCounter = 0;
        Ball.ballCounter = 0;
        if (number == 1)
        {
            SceneManager.LoadScene("scene1");
        }else SceneManager.LoadScene("StartScene");
    }
}
