using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class result : MonoBehaviour {
    public Text highScoreText;
    public Text great;
	// Use this for initialization
	void Start () {
        int score = MainGameData.GetScore() + (Timer.time * 200);

        this.GetComponent<Text>().text = "Score:" + score.ToString();
        if (score > MainGameData.highScore) {
            MainGameData.highScore = score;
            great.text = "GREAT!";
        }
        else { great.text = ""; }
        highScoreText.text = "HIGHSCORE: " + MainGameData.highScore.ToString();
    }

    // Update is called once per frame
    void Update () {
	
	}
}
