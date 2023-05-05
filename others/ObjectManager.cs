using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//オブジェクトタグがObjectであるものを調べたときの動作をまとめたスクリプト
public class ObjectManager : MonoBehaviour
{
    public static string ReObjectName;

    //このスクリプトをインスタンス化しておいて他のスクリプトからも潜入できるようにする
    public static ObjectManager instance;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    //オブジェクトを調べたとき実行する動作（引数はオブジェクト名）
    public void ObjectEvent(string object_name){
        switch(object_name){
            case "TransWall_door":
                //公衆電話ミニゲーム中であるとき
                if(TellGame.instance.TellEventG() == true){
                    TellGame.instance.PushCounter();
                }else{
                    if(TellBoxScript.instance.OpenClose() == false){
                        TellBoxScript.instance.DoorOpen();
                    }else{
                        TellBoxScript.instance.DoorClose();
                    }
                }
                break;
            default:
                break;
        }
    }
    //オブジェクトにカーソルがあった時、画面に表示する動作名を返す関数（引数はオブジェクト名）
    public string ObjectStateName(string object_name){
        switch(object_name){
            case "TransWall_door":
                if(TellBoxScript.instance.OpenClose() == false){
                    ReObjectName = "開ける";
                }else{
                    ReObjectName = "閉める";
                }
                break;
            case "bikeBox":
                ReObjectName = "バイク";
                break;
            default:
                ReObjectName = "登録されていません";
                break;
        }
        return ReObjectName;
    }
}
