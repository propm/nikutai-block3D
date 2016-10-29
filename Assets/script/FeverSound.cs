using UnityEngine;
using System.Collections;

public class FeverSound : MonoBehaviour {
    private AudioSource audio;
    public FeverJudge feverJudge;
    private bool b = true;
	// Use this for initialization
	void Start () {
        audio = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (MainGameData.isFever) {
            if (b)
            {
                audio.PlayOneShot(audio.clip);
                b = false;
            }
        } else { b = true; }
    }
}
