using UnityEngine;
using System.Collections;

public class MainGameData : MonoBehaviour {
	//メインデータ保存用クラス

	public static int Score = 0; //スコア
	public static int Fever = 0; //フィーバーゲージ
	public static bool isFever = false; //フィーバー判定
	public static int MaxFever = 50; //フィーバーゲージの最大値
	public static bool BallInPlay = false;
    public static int highScore = 0;
    public static bool SpeedUp = false;

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
	public static bool GetisFever(){
		return isFever;
	}
	public static void SetisFever(bool f){
		isFever = f;
	}
	public static int GetMaxFever(){
		return MaxFever;
	}
	public static void SetMaxFever(int m){
		MaxFever = m;
	}

	public static bool GetBallInPlay(){
		return BallInPlay;
	}
	public static void SetBallInPlay(bool b){
		BallInPlay = b;
	}

		
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnApplicationQuit()
    {
    }
}
