using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//装備状況について管理するスクリプト
//インベントリ画面の装備状況の最初と最後だけ保持するため
public class EquipManager : MonoBehaviour
{
    //現在装備しているアイテム名を入れる変数
    public static string equip_item;
    //現在何かしら装備しているか判定する変数
    public static bool equip_judge;
    //現在何番目のアイテムを装備しているか判定する変数
    public static int equip_num;
    

    void Start()
    {
        //はじめは何も持っていないためfalseにしておく
        equip_judge = false;
        //はじめは何もアイテムを持っていないためnullにしておく
        equip_item = null;
        //最初は０番目を基準にしておく
        equip_num = 0;
    }

    void Update()
    {
        
    }

    //今何番目のアイテムを装備しているか返す関数
    public static int EquipNum(){
        return equip_num;
    }

    //今アイテムを持っているかどうかを返す関数
    public static bool EquipJudge(){
        return equip_judge;
    }

    //今装備しているアイテム名を返す関数
    public static string EquipItemName(){
        return equip_item;
    }

    //インベントリ画面が閉じられる直前の装備情報を保持する関数
    public static void EquipData(){
        equip_item = InventManager.EquipItem();
        equip_judge = InventManager.Equip_Judge();
        equip_num = InventManager.Equip_Num();
    }
}
