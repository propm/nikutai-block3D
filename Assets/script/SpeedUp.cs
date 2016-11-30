using UnityEngine;
using System.Collections;

public class SpeedUp : MonoBehaviour {
    public GameObject pob;

    void Start () {
        GameObject ob = (GameObject)Instantiate(pob, transform.position, Quaternion.identity);
    }
	
	void Update () {
        Vector3 v = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.4f);
        transform.position = v;

        if(transform.position.z <= -40)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.tag == "Paddle")
        {
            MainGameData.speedUpSound = true;
            MainGameData.SpeedUp = true;
            Destroy(this.gameObject);
        }
    }
}
