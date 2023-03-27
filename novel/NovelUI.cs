using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Canvasにくっつけるスクリプト
//テキストを表示するためのスクリプト
public class NovelUI : MonoBehaviour
{
    //文章が表示されるテキスト
    public Text talkText;
    //テキストが動いているか判定する変数
    public bool text_playing = false;
    //文章が表示されるスピード
    public float textSpeed = 0.1f;

    void Start()
    {
        
    }

     // クリックで次のページを表示させるための関数
    public bool IsClicked()
    {
        //マウスで左クリックしたときtrueを返す
        if (Input.GetKeyDown ("d") || Input.GetKeyDown ("a")){
            return true;
        }
        return false;
    }

    //テキストを作る関数
    //引数は表示するテキスト文章が入る
    public void DrawText(string text){
        //CoDrawText関数をコルーチン実行する
        StartCoroutine(CoDrawText(text));
    }

    //テキストを順々に表示するコルーチン
    IEnumerator CoDrawText(string text){
        //表示しているのでtrueにする
        text_playing = true;
        //時間を初期化する
        float time = 0;
        //テキストを順に表示するためにwhileループさせる
        while(true){
            //1フレーム停止
            yield return null;
            time += Time.deltaTime;

            //クリックすると一気に表示させる（ループを抜ける）
            if(IsClicked()){
                break;
            }
            //Mathf.FloorToIntで(time/textSpeed)以下の最大の整数を受け取る
            //経過時間timeを1文字表示されるtextSpeedで割ることで
            //現在表示されている文字数lenを求める
            int len = Mathf.FloorToInt ( time / textSpeed);
            //現在表示されている文字数が、表示したい文字数よりも大きくなったら
            //つまり表示したい文字列を表示したらループを抜ける
            if (len > text.Length){
                break;
            }
            //文章を表示する場所に今のところ表示できる文字まで表示
            talkText.text = text.Substring(0, len);
        }
        //一度にテキストを表示する
        talkText.text = text;
        //1フレーム停止
        yield return null;
        //すべて表示し終わったからfalseにする
        text_playing = false;
        Debug.Log("CoDrawText末尾");
    }
}
