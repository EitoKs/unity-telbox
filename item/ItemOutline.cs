using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//カメラから出ている光線が当たればアウトラインを強調するスクリプト
//強調させるアセットを使っている
//強調するレイヤーは9番目のレイヤ
//アイテム自身にくっつける
public class ItemOutline : MonoBehaviour
{
    private GameObject HitObject;
    
    void Update()
    {
        //現在、Rayが当たっているオブジェクトをHitObjectに格納する
        HitObject = ItemPicker.RayHitItem();
        //何かしらRayが当たっていればアウトラインを強調する
        if(HitObject != null){
            //アウトラインが強調されていなければ
            if(HitObject.layer == 0 && HitObject == this.gameObject){
                //アウトラインを強調する
                this.gameObject.layer = 9;
            }
        //Rayが当たっていないとき
        } else {
            this.gameObject.layer = 0;
        }
    }
}
