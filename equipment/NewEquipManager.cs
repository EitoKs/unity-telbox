using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//（新しく作った）装備画面を操作するスクリプト
//MainCameraの子オブジェクトのItemBoxにアタッチする
public class NewEquipManager : MonoBehaviour
{
    //現在装備中のオブジェクトを格納する変数
    public static GameObject EquipItemPrefab;
    //現在装備中のオブジェクトのインスタンスを格納する変数
    public static GameObject EquipItem;
    //装備するアイテム名
    public static string ename;
    //装備していたアイテム名
    public static string old_ename;
    //アイテムを装備しているか
    public static bool nowItem;


    //装備アイテムを入れる親オブジェクト
    public static GameObject Itembox;

    // Start is called before the first frame update
    void Start()
    {
        //はじめは何も持っていないためnull
        EquipItemPrefab = null;
        //はじめは何もアイテムを持っていないためnull
        ename = null;
        //何もアイテムを持っていないからfalse
        nowItem = false;
        //スクリプトをつけている自身を入れる
        Itembox = this.gameObject;
    }

    public static void EquipOpen(){
        //アイテムを装備していたら
        if(nowItem == true){
            //一個前に装備していたアイテム名を入れる
            old_ename = ename;
            //現在装備中のアイテム名を受け取る
            ename = EquipManager.EquipItemName();
            //持っているものが変わっていたら装備中のアイテムを破壊
            if(ename != old_ename){
                Destroy(EquipItem);
                //Resourcesフォルダから装備中のプレハブデータを受け取る
                EquipItemPrefab =  (GameObject)Resources.Load(ename);
                //それをItemboxの子オブジェクトとしてインスタンス化
                EquipItem = (GameObject)Instantiate(EquipItemPrefab,Itembox.transform.position, Quaternion.identity);
                EquipItem.transform.parent = Itembox.transform;
                //ローカルポジションとローテーションを０にする
                EquipItem.transform.localPosition = Vector3.zero;
                EquipItem.transform.localRotation = Quaternion.identity;
            }
        }else{
            //現在装備中のアイテム名を受け取る
            ename = EquipManager.EquipItemName();
            //Resourcesフォルダから装備中のプレハブデータを受け取る
            EquipItemPrefab =  (GameObject)Resources.Load(ename);
            //それをItemboxの子オブジェクトとしてインスタンス化
            EquipItem = (GameObject)Instantiate(EquipItemPrefab,Itembox.transform.position, Quaternion.identity);
            EquipItem.transform.parent = Itembox.transform;
            //ローカルポジションとローテーションを０にする
            EquipItem.transform.localPosition = Vector3.zero;
            EquipItem.transform.localRotation = Quaternion.identity;
            //今なにかしらのアイテムを装備している
            nowItem = true;
        }
    }

    public static void EquipClose(){
        //何かしら持っていたら削除する
        if(EquipItem != null){
            Destroy(EquipItem);
            EquipItem = null;
        }
        nowItem = false;
    }
}
