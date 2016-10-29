using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour {
    public int number; 
    // ボタンをクリックした時の処理
    public void ButtonPush()
    {
        Application.LoadLevel("scene1");
        Application.LoadLevel("ScoreScene");
        MainGameData.SetScore(0);
        MainGameData.SetFever(0);
        MainGameData.isFever = false;
        Timer.time = Timer.startTime;
        if (number == 1)
        {
            SceneManager.LoadScene("scene1");
        }else SceneManager.LoadScene("StartScene");
    }
}
