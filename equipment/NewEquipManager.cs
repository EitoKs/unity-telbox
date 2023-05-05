using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//（新しく作った）装備画面を操作するスクリプト
//MainCameraの子オブジェクトのItemBoxにアタッチする
public class NewEquipManager : MonoBehaviour
{
    //現在装備中のオブジェクトを格納する変数
    // public static GameObject EquipItemPrefab;
    public GameObject EquipItemPrefab;
    //現在装備中のオブジェクトのインスタンスを格納する変数
    // public static GameObject EquipItem;
    public GameObject EquipItem;
    //装備するアイテム名
    // public static string ename;
    public string equipName;
    //装備していたアイテム名
    // public static string old_ename;
    public string old_ename;
    //何かしらアイテムを装備しているか
    // public static bool nowItem;
    public bool EquipJudge;
    //現在何番目のアイテムを装備しているか判定する変数
    // public static int equip_num;
    public int equipNum;
    //もう既にアイテムを装備しているか
    public bool nowItem;


    //装備アイテムを入れる親オブジェクト
    // public static GameObject Itembox;
    public GameObject Itembox;

    //このスクリプトをインスタンス化しておいて他のスクリプトからも潜入できるようにする
    public static NewEquipManager instance;

    void Start()
    {
        //このスクリプトをインスタンス化する
        if(instance == null)
        {
            instance = this;
        }
        //はじめは何も持っていないためnull
        EquipItemPrefab = null;
        //はじめは何もアイテムを持っていないためnull
        equipName = null;
        //同上
        old_ename = null;
        //始めは何も持っていないためfalse
        EquipJudge = false;
        //何もアイテムを持っていないからfalse
        nowItem = false;
        //スクリプトをつけている自身を入れる(MainCamera→ItemBox)
        Itembox = this.gameObject;
    }

    //何かしらのアイテムを持っているためアイテムを表示させる関数
    public void EquipOpen(){
        if(nowItem == true){    //もうすでに何かしらアイテムを装備していた場合
            if(equipName != old_ename){     //既に装備しているアイテム名と比較
                Destroy(EquipItem);     //もし、違うアイテムを新たに装備するなら、今装備しているアイテムを削除
                //Resourcesフォルダから装備中のプレハブデータを受け取る
                EquipItemPrefab =  (GameObject)Resources.Load(equipName);
                //それをItemboxの子オブジェクトとしてインスタンス化
                EquipItem = (GameObject)Instantiate(EquipItemPrefab,Itembox.transform.position, Quaternion.identity);
                EquipItem.transform.parent = Itembox.transform;
                //ローカルポジションとローテーションを０にする
                EquipItem.transform.localPosition = Vector3.zero;
                EquipItem.transform.localRotation = Quaternion.identity;
                old_ename = equipName;      //更新しておく
            }
        }else{      //何も装備していない場合
            //現在装備しているアイテム名を入れる
            old_ename = equipName;
            nowItem = true;     //既に何かしらアイテムを装備していることにする
            //Resourcesフォルダから装備中のプレハブデータを受け取る
            EquipItemPrefab =  (GameObject)Resources.Load(equipName);
            //それをItemboxの子オブジェクトとしてインスタンス化
            EquipItem = (GameObject)Instantiate(EquipItemPrefab,Itembox.transform.position, Quaternion.identity);
            EquipItem.transform.parent = Itembox.transform;
            //ローカルポジションとローテーションを０にする
            EquipItem.transform.localPosition = Vector3.zero;
            EquipItem.transform.localRotation = Quaternion.identity;
        }
    }

    public void EquipClose(){
        //何かしら持っていたら削除する
        if(EquipItem != null){
            Destroy(EquipItem);
            EquipItem = null;
            EquipItemPrefab = null;
        }
        old_ename = null;
        equipName = null;
        nowItem = false;
        EquipJudge = false;
    }

    public void EquipData(){
        EquipJudge = InventManager.instance.equip_judge;   //画面を閉じるとき何か装備していたか
        if(EquipJudge == true){    //装備していた場合、アイテム名とアイテム番号を受け取る
            equipName = InventManager.instance.equip_item;
            equipNum = InventManager.instance.equip_num;
        }
    }
}
