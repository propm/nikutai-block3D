using UnityEngine;
using System.Collections;

public class FeverJudge : MonoBehaviour {
	private float count = 0;
	public int redFever = 1; //フィーバーゲージの減算量
	public int MaxFever = 50; //フィーバーゲージの最大値
	public int FeverTime = 15; //フィーバーの継続時間

	private float FeverCount = 0;

	void Start () {
		MainGameData.SetMaxFever (MaxFever);
	}

	void Update () {
		count = Time.deltaTime;

		//時間経過によるフィーバーゲージの減算処理
		if(count >= 1 && MainGameData.GetisFever() == false){
			MainGameData.SetFever (MainGameData.GetFever () - redFever);
			count = 0;
			Debug.Log (MainGameData.GetFever ());
		}

		//フィーバーゲージが最大値を超えた場合のフィーバー判定
		if (MainGameData.GetFever () >= MaxFever) {
			MainGameData.SetisFever (true);
			MainGameData.SetFever (0);
		}

		//フィーバーの継続処理
		if (MainGameData.GetisFever () == true) {
			FeverCount = Time.deltaTime;
			Debug.Log ("true");
			if (FeverCount >= FeverTime) {
				MainGameData.SetisFever (false);
			}
		}

	}
}
