﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FeverSlide : MonoBehaviour {
    public Slider slider;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
            slider.value = MainGameData.GetFever();
    }
}
