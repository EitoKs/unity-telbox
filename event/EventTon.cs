using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class EventTon : MonoBehaviour
{
    //プレイヤーのモデル
    [SerializeField]
    private GameObject PlayerModel;
//------------------------------------------------------------
    //トンネル入り口のメッセージ
    private string[] text01 = {
        "こんなに暗い中、歩くのは危険だ。",
        "車に戻って懐中電灯を取りに戻ろう。"
    };
    private int[] jtext01 = {
        1,1
    };
//-----------------------------------------------------------
    //トンネルを抜けた後のメッセージ
    private string[] text02 = {
        "電話ボックスはあれか？",
        "人がいる気配がしないけど・・・本当に待っているのか？"
    };
    private int[] jtext02 = {
        1,1
    };

    private string uppern = "やすし";  

    //トンネル後のスマホのメッセージ
    private string[] stext01 = {
        "電話ボックスは見つけられたか！",
        "多分、見つけたわ",
        "今、どこにいる？",
        "とりあえず、ボックスに入ってちょうだい！",
        "でも、このボックスって・・・出るんだろ",
        "じゃあ、よろしくな！",
        "おい、メッセージ見てる？",
        "おーい"
    };

    private int[] smyother01 = {
        1,
        0,
        0,
        1,
        0,
        1,
        0,
        0
    };

    private string[] text03 = {
        "やすしのやつ、用件だけ送ってきて会話する気が無ぇな。",
        "てか、電話ボックスの近くに来たことをどうしてわかったんだ？",
        "・・・そうか、近くに潜んでいるんだな！",
        "でも、やすしの目的がサッパリわからないな。"
    };
    private int[] jtext03 = {
        1,1,1,1
    };
//-----------------------------------------------------------

    private string[] text04 = {
        "電話の音が気になるな。"
    };

    private int[] jtext04 = {
        1
    };

//-----------------------------------------------------------
    public void TonEvent01(){
        //文章を表示する
        NovelScript.Novel_instance.NovelUIOpen(text01, jtext01);
    }

    public void TonEvent02(){
        //文章を表示する
        NovelScript.Novel_instance.NovelUIOpen(text02, jtext02);
    }

    public void STonEvent01(){
        //スマホ画面のテキストを表示
        SumahoScript.Sumaho_instance.SumahoOpen(stext01, smyother01, uppern);
    }

    public void TonEvent03(){
        //文章を表示する
        NovelScript.Novel_instance.NovelUIOpen(text03, jtext03);
    }

    public void TonEvent04(){
        //文章を表示する
        NovelScript.Novel_instance.NovelUIOpen(text04, jtext04);
    }
//----------------------------------------------------------------------
    //トンネル入り口のイベントの後少し壁から離れたところに移動させておく
    public void PlayerTonWarp1(){
        PlayerModel.transform.position = new Vector3(17.4f, 0.04f, 19.5f);
    }
    //トンネル出口のイベントの後少し壁から離れたところに移動させておく
    public void PlayerTonWarp2(){
        PlayerModel.transform.position = new Vector3(72.5f, 0.04f, 42.0f);
    }
}
