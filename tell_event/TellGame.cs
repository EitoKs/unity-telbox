using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TellGame : MonoBehaviour
{
    //ボタンを押した回数を格納する
    private int push_counter = 0;
    //ボタンを押す回数のノルマ
    public int clearcount = 5;

    //電話ボックスのゲームをクリアしたか判定用
    public bool tellgameclear = false;

    //現在、公衆電話のミニゲーム中かどうかを判定する変数
    public static bool telleventnow;

    [SerializeField]
    private GameObject transWalltell;

    public static TellGame instance;

    void Start()
    {
        //インスタンスを作り、別のファイルでも関数を使えるようにする
		if(instance == null)
    	{
        	instance = this;
    	}
        telleventnow = false;
    }

    //オブジェクトを調べたときにFキーを押すとカウントされる
    public void PushCounter()
    {
        push_counter++;
        if(push_counter >= clearcount && tellgameclear == false){
            tellgameclear = true;
            //EventManagerS.instance.TellDoorE2();
        }else if(push_counter == 1){
            EventManagerS.instance.TellDoorE1();
        }
    }

    //ボタンを押すゲームがクリアしたかどうかを他のスクリプトに知らせる関数
    public bool Tellgameclear(){
        return tellgameclear;
    }
    //今ミニゲーム中にする関数
    public void TellEventGS(){
        telleventnow = true;
    }
    //ミニゲームを終わらせる関数
    public void TellEventGE(){
        telleventnow = false;
        transWalltell.SetActive(false);     //公衆電話を調べられなくさせる
    }
    //現在ミニゲーム中かどうかを判定する関数
    public bool TellEventG(){
        return telleventnow;
    }
}
