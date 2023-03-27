using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    //UIが表示されているかどうかを判定する変数
    //メニュー画面やボタン操作があるときにtrueにする
    //プレイヤーを動かしたくないとき
    public static bool ui_triger;
    //このスクリプトのインスタンスを入れる変数
	public static UIController instance;

    void Start(){
        if(instance == null)
    	{
        	instance = this;
    	}
        ui_triger = false;
    }

    // Update is called once per frame
    void Update()
    {
        ui_triger = false;
        if(PauseScript.MenuJudg() == true || InventScript.InventJudg() == true || NovelScript.NovelJudg() == true || NowEventScript.EventJudge() == true || SumahoScript.SumahoJudg() == true){
            ui_triger = true;
        }
    }

    //ui_trigerを他のスクリプトに伝える関数
	public static bool UIJudg(){
		return ui_triger;
	}
}
