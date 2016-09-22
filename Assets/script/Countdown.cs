using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Countdown : MonoBehaviour
{
    public int text;

    void Start()
    {
        this.GetComponent<Text>().text = text.ToString();
    }

    void Update() { this.GetComponent<Text>().text = text.ToString(); }
}
