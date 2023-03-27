using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//手をまとめたオブジェクトを表示するスクリプト
public class handShow : MonoBehaviour
{
    //手をまとめたオブジェクトをインスペクタ上で設定
    public GameObject HandInstance;

    //赤い窓のオブジェクトをインスペクタ上で設定
    public GameObject RedWindowInstance;

    //タイマーのプレハブをインスペクタ上で設定
    [SerializeField]
    private GameObject TimeManagerPrefab;
    //上記のプレハブのインスタンス
    private GameObject TimeManagerInstance;

    public static handShow instance;

    void Start(){
        //インスタンスを作り、別のファイルでも関数を使えるようにする
		if(instance == null)
    	{
        	instance = this;
    	}
    }
//---------------------------------------------------------------
    public void HandShow(){
        HandInstance.SetActive(true);
    }

    public void HandDes(){
        HandInstance.SetActive(false);
    }
//---------------------------------------------------------------
    public void RedwindowShow(){
        RedWindowInstance.SetActive(true);
    }

    public void RedwindowDes(){
        RedWindowInstance.SetActive(false);
    }
//---------------------------------------------------------------
    public void TimeManagerShow(){
        if(TimeManagerInstance == null){
            //手のオブジェクトをインスタンス化する
            TimeManagerInstance = GameObject.Instantiate(TimeManagerPrefab) as GameObject;
        }
    }

    public void TimeManagerDes(){
        if(TimeManagerInstance != null){
            Destroy(TimeManagerInstance);
        }
    }
}
