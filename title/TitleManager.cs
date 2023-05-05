using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Timeline;
using UnityEngine.Playables;
using TMPro; //TextMeshProを扱う際に必要
//Startボタンを押した後に流れるロード画面についてのスクリプト
public class TitleManager : MonoBehaviour
{
    //非同期動作で使用するAsyncOperation
	private AsyncOperation async;
	//シーンロード中に表示するUI
	[SerializeField]
	private GameObject loadUI;
	//読み込み率を表示するスライダー
	[SerializeField]
	private Slider slider;
	//ボタンを押したときに流れる音
	//[SerializeField]
	//private AudioSource buttonaudio;
	//
	[SerializeField]
	private PlayableDirector TitleDirector;

	[SerializeField]	//エンドの収集数を表示するテキスト
	private TextMeshProUGUI endcount;

    void Start()
    {
		CursorScript.CursorFree();		//カーソルを動かせるようにする
        endcount.text = "エンド数\n"+ EndManager.end_count + " / 2";
    }

    public void MoveGame1(){
		//buttonaudio.GetComponent<AudioSource>().PlayOneShot(buttonaudio.clip);
		TitleDirector.Play();
    }

	public void LoadGameScene(){
		//ロードUIを表示
		loadUI.SetActive(true);
		//コルーチンを始める
        StartCoroutine("LoadData");
	}


    IEnumerator LoadData() {
		// シーンの読み込みをする
		async = SceneManager.LoadSceneAsync("Game1");
		//　読み込みが終わるまで進捗状況をスライダーの値に反映させる
		while(!async.isDone) {
			var progressVal = Mathf.Clamp01(async.progress / 0.9f);
			slider.value = progressVal;
			yield return null;
		}
	}
}
