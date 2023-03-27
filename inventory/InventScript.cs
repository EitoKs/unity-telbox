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

	//[SerializeField]
	//　装備画面を表示するUIのプレハブ
	//private GameObject EquipUIPrefab;
	//　装備画面UIのインスタンス
	//public static GameObject EquipUIInstance;
	//装備アイテムを表示するオブジェクト
	//private GameObject Itembox;

    //装備画面に映るアイテムの3D画像のプレハブ
	//[SerializeField]
	//private GameObject EquipItemPrefab;
	//　アイテムの画像のインスタンス
	//public static GameObject EquipItemInstance;

    //インベントリ画面が表示されているかどうかを判定する変数
    public static bool invent_triger = false;

	//装備をしているかどうかを判定する関数
	private bool Equip_Judge;
	//装備画面を開いているかどうかを判定
	//public static bool equip_triger = false;



    // Update is called once per frame
    void Update()
    {
		//ポーズ画面が開かれていないかつイベント中ではない時アイテム画面を開ける
		if(PauseScript.MenuJudg() == false && NowEventScript.EventJudge() == false){
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
					EquipManager.EquipData();
					//インスタンスを削除
                	Destroy (InventUIInstance);
					//インスタンスを削除
                	Destroy (InventItemInstance);


					//装備をしているかどうかを判定
					Equip_Judge = EquipManager.EquipJudge();
					//装備画面を開くかどうかを判定する
					//何かしら装備をしているか
					if(Equip_Judge == true){
						NewEquipManager.EquipOpen();	//装備画面を開く
					}else{
						NewEquipManager.EquipClose();	//装備画面を閉じる
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

	//装備画面を表示する関数
    // void EquipOpen(){
    //     //装備画面を閉じているとき
    //     //if(equip_triger == false && EquipUIInstance == null){
	// 	if(equip_triger == false){
    //         //装備画像に表示するオブジェクトをインスタンス化する
	// 		//EquipItemInstance = GameObject.Instantiate (EquipItemPrefab) as GameObject;
    //         //インスタンス化する
	// 		//EquipUIInstance = GameObject.Instantiate (EquipUIPrefab) as GameObject;
	// 		Itembox.SetActive(true);
    //         //装備画面を開いている判定にする
    //         equip_triger = true;
    //     }
    // }

    //装備画面を消す関数
    // public static void EquipClose(){
    //     //インスタンスを削除
    //     //Destroy (EquipUIInstance);
	// 	//インスタンスを削除
    //     //Destroy (EquipItemInstance);
	// 	//Itembox.SetActive(false);
    //     //装備画面を開いている判定にする
    //     equip_triger = false;
    // }

	//装備画面を開いているかどうかを返す関数
    // public static bool EquipTriger(){
    //     return equip_triger;
    // }
}
