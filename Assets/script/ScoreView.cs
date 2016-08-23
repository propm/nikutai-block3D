using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour {
	private int score;
	public Text ScoreText;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		score = MainGameData.GetScore ();
		ScoreText.text = "Score: " + score.ToString();
	}
}
