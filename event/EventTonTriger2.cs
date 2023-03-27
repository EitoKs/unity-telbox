using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//トンネルを抜けたときに発生するイベント用
public class EventTonTriger2 : MonoBehaviour
{
    //トンネルを抜けたときのイベントを見たか判定
    private bool toneventj = false;
    void Update()
    {
        
    }

    //void OnCollisionEnter(Collision collision){
    void OnTriggerEnter(Collider collision){    //isTriggerをOnにしたときに変更
        //懐中電灯を手に入れていなければ進めない
        if(ItemManager.instance.itemFlags[1] == true){
            //プレイヤーと接触したらイベントが発生
            if(collision.gameObject.tag == "Player"){
                //電話の音が鳴るイベントがまだのとき
                if(EventTell1.TellRingJudge() == false){
                    //一度トンネルから出るイベントを見ると
                    if(toneventj == false){
                        EventManagerS.instance.TonEvent2();
                        toneventj = true;
                        EventTonEnemy2.instance.EneTonDes();
                    }
                }else{
                //電話が鳴るイベントを見て、その後、走るイベントでなければ実行
                    if(EventRun.instance.NowRunEvent() == false){
                        EventManagerS.instance.TonEvent3();
                    }
                }
            }
        }
    }

    //壁を消す関数
    public void TonDestroy(){
        //オブジェクトを削除する（thisだけでは消えない）
        DestroyImmediate(this.gameObject );
    }
}
