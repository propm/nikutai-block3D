using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour {
    
    // ボタンをクリックした時の処理
    public void ButtonPush()
    {
        Application.LoadLevel("scene1");
        Application.LoadLevel("ScoreScene");
        MainGameData.SetScore(0);
        MainGameData.SetFever(0);
        SceneManager.LoadScene("scene1");
    }
}
