using UnityEngine;
using System.Collections;

public class Play : MonoBehaviour {
    public MovieTexture rend;
    void Start()
    {
        this.GetComponent<Renderer>().material.mainTexture = rend;
        rend.loop = true;
        rend.Play();

    }

    // Update is called once per frame
    void Update () {
    }
}
