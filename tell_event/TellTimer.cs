using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//公衆電話内のイベントを管理するスクリプト
public class TellTimer : MonoBehaviour
{
    //現在の経過時間を計測する変数
    private float timer = 0.0f;
    //ミニゲームの制限時間
    public float timerlimit = 20.0f;
    //ゲームがクリアしたかの判定を受け取る変数
    private bool stopTime = false;
    //制限時間を過ぎたかどうかを判定する変数
    public bool timeup = false;
    //手を出した個数
    private int now_num = 1;
    //手を出現させるランダムな間隔
    private float handinterval;
    //出現間隔を制御する変数
    private float intervaltime;

    void Start(){
        intervaltime = 0.0f;
        handinterval = Random.Range(0.7f, 1.5f);
        TellGame.instance.TellEventGS();
    }

    void Update()
    {
        if(TellGame.instance.TellEventG() == true){
            //クリアしたら下の処理を実行する
            if(stopTime == true){
                TellGame.instance.TellEventGE();    //公衆電話を調べられなくさせる
                EventManagerS.instance.TellDoorE2();
                handShow.instance.HandDes();    //手のオブジェクトを消す
                return;
            //タイムアップした時は以下の処理を実行する
            }else if(timeup == true){
                TellGame.instance.TellEventGE();    //公衆電話を調べられなくさせる
                EventManagerS.instance.TellDoorE2();
                handShow.instance.HandDes();    //手のオブジェクトを消す
                return;
            }
            //時間をカウントさせる
            timer += Time.deltaTime;
            intervaltime += Time.deltaTime;
            //ランダムなタイミングで手を出現させる
            if(intervaltime >= handinterval && now_num <= 20){
                HandTimer.instance.OneHandShow(now_num);
                now_num++;

                intervaltime = 0.0f;
                handinterval = Random.Range(0.7f, 1.5f);
                StartCoroutine(WindowCling());
            }

            //制限時間を過ぎたらゲームオーバー判定にする
            if(timer >= timerlimit){
                timeup = true;
            }
            stopTime = TellGame.instance.Tellgameclear();
        }
    }

    private IEnumerator WindowCling(){
        handShow.instance.RedwindowShow();
        yield return new WaitForSeconds(0.5f);
        handShow.instance.RedwindowDes();
    }
}
