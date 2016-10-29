using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BlockMaker : MonoBehaviour {
	private int Child; //子オブジェクトの数
	private int countStage = 0; //ステージ番号のカウント
    private int clear = 0; //クリア判定
	public GameObject Stage0;
	public GameObject Stage1;
	public GameObject Stage2;
	public GameObject Stage3;
	public GameObject Stage4;
	public GameObject Stage5;
	public GameObject[] Stages;
	private GameObject Stage;

    public Text finishText;
    public AudioSource audio;
    bool b = true;

	void Start () {
		Stages = new GameObject[]{ Stage0, Stage1, Stage2, Stage3, Stage4, Stage5 };
		Stage = (GameObject)Instantiate (Stages[0], new Vector3 (0, 0, 0), Quaternion.identity);
		Stage.transform.parent = transform;
	}

	void Update () {
		Child = transform.childCount;
		if (Child <= 0) {
            if (clear >= 4)
            {
                clear++;
            }else{
                countStage++;
                Stage = (GameObject)Instantiate(Stages[countStage], new Vector3(0, 0, 0), Quaternion.identity);
                Stage.transform.parent = transform;
                clear++;
            }
		}
        //クリアしたらスコアシーンに遷移する
        if((clear == 5)&&(b)) {
            StartCoroutine("Clear");
            b = false;
        }
	}
    IEnumerator Clear() {
        audio.PlayOneShot(audio.clip);
        Time.timeScale = 0.001f;
        finishText.text = "FINISH!";
        yield return new WaitForSeconds(0.002f);
        SceneManager.LoadScene("ScoreScene");
    }
}
