using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FeverView : MonoBehaviour {
	private int Fever;
	private bool isFever;
	public Text FeverText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Fever = MainGameData.GetFever ();
		isFever = MainGameData.GetisFever ();
		if (isFever == true) {
			FeverText.text = "Fever!";
            FeverText.fontSize = 35;
            FeverText.color = Color.yellow;
		} else {
			FeverText.text = "Fever: " + Fever.ToString ();
            FeverText.fontSize = 20;
            FeverText.color = Color.green;
        }
	}
}
