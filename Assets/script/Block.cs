using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {
	public int AddScore = 500;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
}
