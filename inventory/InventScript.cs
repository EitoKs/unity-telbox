using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//インベントリ画面を開閉するためのスクリプト
public class InventScript : MonoBehaviour
{
    [SerializeField]
	//　インベントリ画面にした時に表示するUIのプレハブ
	private GameObject InventUIPrefab;
	//　インベントリUIのインスタンス
	private GameObject InventUIInstance;
    //画面中央のポインター
    [SerializeField]
    private GameObject item_canvas;
	//インベントリ画面に映るアイテムの3D画像のプレハブ
	[SerializeField]
	private GameObject InventItemPrefab;
	//　アイテムの画像のインスタンス
	private GameObject InventItemInstance;

    //インベントリ画面が表示されているかどうかを判定する変数
    public static bool invent_triger = false;

	//装備をしているかどうかを判定する関数
	private bool Equip_Judge;

    void Update()
    {
		//ポーズ画面が開かれていないかつイベント中ではない時アイテム画面を開ける
		if(PauseScript.MenuJudg() == false && NowEventScript.EventJudge() == false && Continue.ContinueJudge() == false && SumahoScript.SumahoJudg() == false && NovelScript.NovelJudg() == false){
        	//Tabキーを押すとポーズ画面を開く
			if (Input.GetKeyDown ("tab")) {
            	//プレハブがインスタンス化されてなければインスタンス化する
				if (InventUIInstance == null && invent_triger == false) {
                	item_canvas.SetActive(false);
					//インベントリ画像オブジェクトをインスタンス化する
					InventItemInstance = GameObject.Instantiate (InventItemPrefab) as GameObject;
                	//インスタンス化する
					InventUIInstance = GameObject.Instantiate (InventUIPrefab) as GameObject;
					// カーソルロックを解除
        			//CursorScript.CursorFree();
					//メニューを開いているときの判定
					invent_triger = true;
                	//ゲームの流れを止める
					Time.timeScale = 0f;
				} else if(invent_triger == true){ //すでにUIがインスタンス化されていればインスタンスを削除
					//インスタンスを削除する直前のデータを確保する
					NewEquipManager.instance.EquipData();
					//インスタンスを削除
                	Destroy (InventUIInstance);
					//インスタンスを削除
                	Destroy (InventItemInstance);

					//何かしら装備をしているかどうかを判定
					Equip_Judge = NewEquipManager.instance.EquipJudge;
					//装備画面を開くかどうかを判定する
					//何かしら装備をしているか
					if(Equip_Judge == true){
						NewEquipManager.instance.EquipOpen();	//装備画面を開く
					}else{
						NewEquipManager.instance.EquipClose();	//装備画面を閉じる
					}

                	item_canvas.SetActive(true);
		        	//メニューを閉じたときの判定
		        	invent_triger = false;
		        	// カーソルロックをする
                	CursorScript.CursorLock();
                	//時間の流れを再開する
		        	Time.timeScale = 1f;
				}
        	}
		}
    }

    //インベントリ画面を開いていることを他のスクリプトに伝える関数
	public static bool InventJudg(){
		return invent_triger;
	}
}
