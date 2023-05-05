using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    [SerializeField]
	//　ポーズした時に表示するUIのプレハブ
	private GameObject pauseUIPrefab;
	//　ポーズUIのインスタンス
	private GameObject pauseUIInstance;
	//画面中央のポインター
    [SerializeField]
    private GameObject item_canvas;

	//メニュー画面が表示されているかどうかを判定する変数
    public static bool menu_triger = false;
	//このスクリプトのインスタンスを入れる変数
	public static PauseScript Pause_instance;

	void Update () {
		if(NowEventScript.EventJudge() == false && InventScript.InventJudg() == false && Continue.ContinueJudge() == false && SumahoScript.SumahoJudg() == false && NovelScript.NovelJudg() == false){
        	//”Q”キーを押すとポーズ画面を開く
			if (Input.GetKeyDown ("q")) {
            	//プレハブがインスタンス化されてなければインスタンス化する
				if (pauseUIInstance == null && menu_triger == false) {
					//インスタンスを作り、別のファイルでも関数を使えるようにする
					if(Pause_instance == null)
    				{
        				Pause_instance = this;
    				}
                	item_canvas.SetActive(false);
                	//インスタンス化する
					pauseUIInstance = GameObject.Instantiate (pauseUIPrefab) as GameObject;
					// カーソルロックを解除
        			CursorScript.CursorFree();
					//メニューを開いているときの判定
					menu_triger = true;
                	//ゲームの流れを止める
					Time.timeScale = 0f;
				} else if(menu_triger == true){ //すでにUIがインスタンス化されていればインスタンスを削除
					ExitPause();
				}
			}
		}
	}
	//メニュ画面を開いていることを他のスクリプトに伝える関数
	public static bool MenuJudg(){
		return menu_triger;
	}

	//ポーズ画面を閉じたときの処理
	public void ExitPause(){
		//インスタンスを削除
        Destroy (pauseUIInstance);
        item_canvas.SetActive(true);
		//メニューを閉じたときの判定
		menu_triger = false;
		// カーソルロックをする
        CursorScript.CursorLock();
        //時間の流れを再開する
		Time.timeScale = 1f;
	} 
}
