using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ノベルテキストの表示・非表示を管理するスクリプト
public class NovelScript : MonoBehaviour
{
    [SerializeField]
	//ノベルテキストを表示するUIのプレハブ
	private GameObject NovelUIPrefab;
	//ノベルテキストUIのインスタンス
	private GameObject NovelUIInstance;

    //ノベルテキスト画面が表示しているかどうか判定する変数
    public static bool novel_triger;
    //このスクリプトのインスタンスを入れる変数
	public static NovelScript Novel_instance;

    void Start(){
        novel_triger = false;
        //インスタンスを作り、別のファイルでも関数を使えるようにする
		if(Novel_instance == null)
    	{
        	Novel_instance = this;
    	}
    }

    //ノベルテキストを表示するUIを開く関数
    //引数は表示したいテキストの内容を格納した配列
    public void NovelUIOpen(string[] noveltext, int[] novelother){
        //ノベルテキストを表示する画面が閉じていたとき
        if(novel_triger == false){
            //インスタンス化する
			NovelUIInstance = GameObject.Instantiate (NovelUIPrefab) as GameObject;
            //ノベルUIを表示している判定にする
            novel_triger = true;
            //カーソルをロックしておく
            CursorScript.CursorLock();
            //表示するテキスト文章を受け取る
            TextWriter.Novel_Text = noveltext;
            //誰が話しているかの判定を受け取る
            TextWriter.Novelother = novelother;
        }
    }

    //ノベルテキストを表示するUIを消す関数
    public void NovelUIClose(){
        if(novel_triger == true){
            Debug.Log("ノベルを表示するUIを消すところだよ");
            //インスタンスを削除
            Destroy (NovelUIInstance);
            //カーソルをロックしておく
            CursorScript.CursorLock();
            //1秒後に動かせるようにする
            Invoke("NovelClose", 1.0f);
        }
    }

    //ノベルテキスト画面を開いていることを他のスクリプトに伝える関数
	public static bool NovelJudg(){
		return novel_triger;
	}

    //ノベル画面を閉じるか決める
    public void NovelClose(){
        novel_triger = false;
        //止めているタイムラインを再開させる
        EventManagerS.instance.restart();
    }
}
