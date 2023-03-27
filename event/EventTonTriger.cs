using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//懐中電灯を手に入れていないとき、トンネルに入れないイベント用
public class EventTonTriger : MonoBehaviour
{
    void Update()
    {
        //懐中電灯を入手すれば壁自体を消す
        if(ItemManager.instance.itemFlags[1] == true){
            //オブジェクトを削除する（thisだけでは消えない）
            DestroyImmediate(this.gameObject );
        }
    }

    //void OnCollisionEnter(Collision collision){
    void OnTriggerEnter(Collider collision){    //isTriggerをOnにしたときに変更
        //Debug.Log("当たっているよ");
        //懐中電灯を手に入れていなかったら
        if(ItemManager.instance.itemFlags[1] == false){
            //プレイヤーと接触したらイベントが発生
            if(collision.gameObject.tag == "Player"){
                EventManagerS.instance.TonEvent();
            }
        }
    }
}
