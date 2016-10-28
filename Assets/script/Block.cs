using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {
	public int AddScore = 500;
	public int FeverAddScore = 750;
	public GameObject thisBlock;
	Collider BlockCollider;
    public GameObject block;
    public Material materiale;
	// Use this for initialization
	void Start () {
		BlockCollider = thisBlock. GetComponent<Collider>();
	}


	// Update is called once per frame
	void Update () {
		if (MainGameData.GetisFever () == true) {
			BlockCollider.isTrigger = true;
		} else {
			BlockCollider.isTrigger = false;
		}
        
	}

	void OnCollisionEnter(Collision collision) {
		//衝突判定
		if (collision.gameObject.tag == "Ball") {
			//相手のタグがBallならば、自分を消す
			MainGameData.SetScore(MainGameData.GetScore()+AddScore); 
			if (MainGameData.GetisFever () == false) {
				MainGameData.SetFever (MainGameData.GetFever () + 4);
			}
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter(Collider trigger){
		if(trigger.gameObject.tag== "Ball"){
			MainGameData.SetScore(MainGameData.GetScore()+FeverAddScore); 
			Destroy(this.gameObject);
		}
	}
}
