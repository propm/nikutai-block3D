using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour {

    // ボタンをクリックした時の処理
    public void ButtonPush()
    {
        Debug.Log("clicked");
        Application.LoadLevel("scene1");
        Application.LoadLevel("ScoreScene");
        SceneManager.LoadScene("scene1");
    }
}
