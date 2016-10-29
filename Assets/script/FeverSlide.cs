using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FeverSlide : MonoBehaviour {
    public Slider slider;
    float feverCage = 50;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (MainGameData.GetisFever()) {
            feverCage -= Time.deltaTime;
            slider.value = (feverCage * 3.33f);
        } else {
            slider.value = MainGameData.GetFever();
            feverCage = 15;
        }
    }
}
