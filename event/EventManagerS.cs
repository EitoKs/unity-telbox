using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

//ここでイベントを実行させる
public class EventManagerS : MonoBehaviour
{
    //イベントを調べたかどうか
    private bool search_triger;
    //イベント名を受け取る
    private string event_name;
    //イベント確認判定（デバッグ用）
    [SerializeField]
    public bool[] eventFlags = new bool[10];
    //今イベントをしているかどうかを判定する変数
    public static bool event_triger;

    //ここにインスペクター上であらかじめ複数セットしておく
    // [SerializeField]
    // private TimelineAsset[] timelines;
    public PlayableDirector NowDirector;

    public PlayableDirector[] director;

    //今何番目のイベントをしているか管理する関数
    public static int nowEventnum;

    //このスクリプトをインスタンス化しておいて他のスクリプトからも潜入できるようにする
    public static EventManagerS instance;

    public static string re_event_name;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

//--------------------------------------------------------------------------------------------
    //ステージがロードされたときに実行されるオープニングイベント
    void Start(){
        NowDirector = director[0];
        //NowDirector = director[11];     //踊り確認用
        NowDirector.Play();
    }

    public void GetEventJudge(string event_name){
        //イベントを調べたかどうか
        search_triger = ItemPicker.SearchEventJudg();
        //イベントを調べたなら以下の内容を実行
        if(search_triger == true){
            //switch文でイベントを判別
            switch(event_name){
                case "車":
                    //走るイベントのときにクリックしたときエンディングイベントを実行する
                    if(EventRun.instance.NowRunEvent() == true){
                        //敵が追いかけるイベントでないことにする
                        EventRun.instance.RunEventOff();
                        NowDirector = director[11];
                        eventFlags[11] = true;
                    }
                    else if(eventFlags[1] == true){
                        //イベント用の関数を入れる（引数に動かしたいタイムラインを入れる）
                        NowDirector = director[7];
                        eventFlags[7] = true;
                    }else{
                        //イベント用の関数を入れる（引数に動かしたいタイムラインを入れる）
                        NowDirector = director[1];
                        eventFlags[1] = true;
                    }
                    break;
                case "TransWall_tell":
                    if(TellGame.instance.TellEventG() == true){
                        NowDirector = director[8];
                        eventFlags[8] = true;
                    }else{
                        if(TellBoxScript.instance.OpenClose() == false){
                            NowDirector = director[4];
                            eventFlags[4] = true;
                        }else{
                            NowDirector = director[6];
                            eventFlags[6] = true;
                        }
                    }
                    break;
                case "バイクのキー":
                    NowDirector = director[12];
                    eventFlags[12] = true;
                    break;
                case "bikeBox":
                    //敵が追いかけるイベントでないことにする
                    EventRun.instance.RunEventOff();
                    NowDirector =  director[13];
                    eventFlags[13] = true;
                    break;
                default:
                    break;
            }
            NowDirector.Play();
        }
    }

    public string EventName(string event_name){
        switch(event_name){
            case "車":
                if(EventRun.instance.NowRunEvent() == true){
                    re_event_name = "車に乗る";
                }else{
                    re_event_name = "車";
                }
                break;
            case "TransWall_tell":
                if(TellGame.instance.TellEventG() == true){
                    re_event_name = "公衆電話";
                }else{
                    re_event_name = "電話に出る";
                }
                break;
            case "バイクのキー":
                re_event_name = "？？？";
                break;
            case "bikeBox":
                re_event_name = "やすしのバイク";
                break;
            default:
                re_event_name = "イベント名が登録されていません";
                break;
        }
        return re_event_name;
    }

    //懐中電灯を入手する前にトンネルに近づこうとしたとき
    public void TonEvent(){
        NowDirector = director[2];
        NowDirector.Play();
    }

    public void TonEvent2(){
        NowDirector = director[3];
        NowDirector.Play();
    }

    public void TonEvent3(){
        NowDirector = director[5];
        NowDirector.Play();
    }

    public void TellDoorE1(){
        NowDirector = director[9];
        NowDirector.Play();
    }

    public void TellDoorE2(){
        NowDirector = director[10];
        NowDirector.Play();
    }
//------------------------------------------------------
    //イベントを開始させる関数
    //引数は開始させたいタイムライン
    public void eventstart(PlayableDirector nowDirector){
        nowDirector.Play();
    }

    //実行中のタイムラインを一時停止させる関数
    public void pause(){
        NowDirector.Pause();
    }
    //一時停止中のタイムラインを再開させる関数
    public void restart(){
        NowDirector.Resume();
    }
    //タイムラインを停止させる関数
    public void stoptimeline(){
        NowDirector.Stop();
    }
}
