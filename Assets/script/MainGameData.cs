using UnityEngine;
using System.Collections;

public class MainGameData : MonoBehaviour {
	//メインデータ保存用クラス

	public static int Score = 0; //スコア
	public static int Fever = 0; //フィーバーゲージ

	public static int GetScore(){
		return Score;
	}
	public static void SetScore(int s){
		Score = s;
	}

	public static int GetFever(){
		return Fever;
	}
	public static void SetFever(int f){
		Fever = f;
	}
		
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
