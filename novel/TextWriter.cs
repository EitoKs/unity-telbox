using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//ノベルの文章を書くためのスクリプト
public class TextWriter : MonoBehaviour
{
    //NovelUIをアタッチしたCanvasを入れる
    public NovelUI novelui;
    //表示する文章を読み進むか戻るのか管理する変数
    public bool text_back;
    //表示する文章を格納する配列
    public static string[] Novel_Text;
    //誰が話しているのかを判定する配列
    public static int[] Novelother;
    //現在読んでいる文章が1文目かどうかを判定する変数
    public bool first_text;

    //左のキー入力を促す文字
    [SerializeField] Text LeftIcon;
    //右のキー入力を促す文字
    [SerializeField] Text RightIcon;

    //名前を表示するText（話している人名を表示するため）
    [SerializeField] Text NameText;


    void Start()
    {
        //読み戻しをfalseにしておく
        text_back = false;
        //はじめは1文目からだからtrueにしておく
        first_text = true;
        //右のキー入力を促す文字はつけておく
        RightIcon.enabled = true;
        //はじめに左のキー入力を促す文字は消しておく
        LeftIcon.enabled = false;
        //文章を表示させるコルーチンを実行する
        StartCoroutine(Cotest(Novel_Text, Novelother));
    }

    // クリック待ちのコルーチン
    IEnumerator Skip()
    {
        //順々に表示しているとき待機させておく（第1関門）
        while (novelui.text_playing) yield return null;
        //クリックされたとき待機させておく
        while(true){
            //dキーを押すと読み進める
            if(Input.GetKeyDown ("d")){
                text_back = false;
                break;
            //aキーを押すと一文前の文章に戻る
            }else if(Input.GetKeyDown ("a") && first_text == false){
                text_back = true;
                break;
            //キーを押されない限り待機
            }else{
                yield return null;
            }
        }
    }
    
     // 文章を表示させるコルーチン
    IEnumerator Cotest(string[] Novel_Text, int[] Novel_other)
    {
        //入れた文章数まで繰り返し処理
        for(int i=0; i < Novel_Text.Length; i++){
            //今1文目かどうかを判定
            if(i == 0){
                LeftIcon.enabled = false;
                first_text = true;
            }else{
                if(LeftIcon.enabled == false){
                    LeftIcon.enabled = true;
                }
                first_text = false;
            }

            switch(Novel_other[i]){
                case 0:     //ナレーションはなし
                    NameText.text = "";
                    break;
                case 1:     //主人公が話している時
                    NameText.text = "しんじ";
                    break;
                case 2:     //電話の主（幽霊）
                    NameText.text = "？？？";
                    break;
                default :
                    break;
            }

            //文章を表示させる
            novelui.DrawText(Novel_Text[i]);
            yield return StartCoroutine("Skip");
            //読み直しボタン(aキー)を押したとき、押したときの数字-1のiが代入される
            //こっちに戻った時余計に＋1されるからマイナス２しておく
            if(text_back == true && i > 0){
                i = i - 2;
            }
        }
        //すべて表示しきったら画面を閉じる
        NovelScript.Novel_instance.NovelUIClose();
    }
}
