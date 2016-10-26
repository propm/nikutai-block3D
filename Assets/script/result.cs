using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class result : MonoBehaviour {
    public Timer timer;
	// Use this for initialization
	void Start () {
        int score = MainGameData.GetScore();
        this.GetComponent<Text>().text = "Score:" + score.ToString() + Timer.getTime() * 50;
    }

    // Update is called once per frame
    void Update () {
	
	}
}
