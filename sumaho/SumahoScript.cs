using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//チャット風画面のUIを表示するためのスクリプト
public class SumahoScript : MonoBehaviour
{
    [SerializeField]
	//　スマホ画面にした時に表示するUIのプレハブ
	private GameObject SumahoUIPrefab;
	//　スマホUIのインスタンス
	private GameObject SumahoUIInstance;

    //スマホ画面が開かれているか判定する変数
    public static bool sumaho_triger;

    //このスクリプトのインスタンスを入れる変数
	public static SumahoScript Sumaho_instance;

    void Start()
    {
        sumaho_triger = false;
        //インスタンスを作り、別のファイルでも関数を使えるようにする
		if(Sumaho_instance == null)
    	{
        	Sumaho_instance = this;
    	}
    }

    //スマホ画面を開く関数
    //引数は左から順に
    //・チャットのテキスト文章
    //・メッセージを話している人名の判別用の配列
    //・一番上に表示する名前
    public void SumahoOpen(string[] Chat_Text, int[] MyOther, string upperName){
        if(SumahoUIInstance == null && sumaho_triger == false){
            //インスタンス化する
			SumahoUIInstance = GameObject.Instantiate (SumahoUIPrefab) as GameObject;
            //開いている判定にする
            sumaho_triger = true;
            //ここで引数を渡して文章を出す
            SumahoManager.chattext = Chat_Text;
            SumahoManager.myother = MyOther;
            SumahoManager.upper_name = upperName;
            //ゲームの流れを止める
			Time.timeScale = 0f;
            Debug.Log("スマホ画面が開いたよ");
        }
    }

    //スマホ画面を閉じる関数
    public void SumahoClose(){
        if(sumaho_triger == true){
            //インスタンス化する
			Destroy (SumahoUIInstance);
            //開いていない判定にする
            //sumaho_triger = false;
            //ゲームの流れを元に戻す
			Time.timeScale = 1f;
            //Debug.Log("スマホ画面を閉じたよ");
            //1秒後に動かせるようにする
            Invoke("SumahoCloseJ", 1.0f);
        }
    }

    //スマホ画面を閉じるか決める
    public void SumahoCloseJ(){
        sumaho_triger = false;
        //止めているタイムラインを再開させる
        EventManagerS.instance.restart();
    }

    public static bool SumahoJudg(){
        return sumaho_triger;
    }
}
