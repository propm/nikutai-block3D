using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FeverSlide : MonoBehaviour {
    public Slider slider;
    float feverCage = 50f;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (MainGameData.GetisFever()) {
            feverCage -= 0.1f;
            slider.value = feverCage;
        } else {
            slider.value = MainGameData.GetFever();
            feverCage = 50f;
        }
        
    }
}
