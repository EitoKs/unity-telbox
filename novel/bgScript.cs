using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//背景を表示するスクリプト
public class bgScript : MonoBehaviour
{
    //背景用のCanvasを表示するスクリプト
    [SerializeField]
    private GameObject bgUI;
    private GameObject bgUIInstance;
    
    //背景を表示する関数
    //プレハブをインスタンス化する
    public void BgOpen(){
        bgUIInstance = GameObject.Instantiate (bgUI) as GameObject;
    }

    //背景を消す関数
    public void BgClose(){
        Destroy(bgUIInstance);
    }
}
