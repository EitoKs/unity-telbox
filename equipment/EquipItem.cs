using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//装備画面に表示する情報を管理するスクリプト
//装備画面が出るときにのみ発動する
public class EquipItem : MonoBehaviour
{
    //"EquipItem"タグがついているオブジェクトを複数格納する変数
    public static GameObject[] EquipItems;
    //装備中のアイテム名比較用
    public static string ename;
    //現在表示中のオブジェクトを格納する変数
    public static GameObject NowItems;

    // Start is called before the first frame update
    void Start()
    {
        //"EquipItem"タグがついているオブジェクトをすべて入れる
        EquipItems = GameObject.FindGameObjectsWithTag("EquipItem");
        //アイテムをすべて表示する
        foreach(GameObject Items in EquipItems){
            Items.SetActive(true);
        }
        //現在装備中のアイテム名を受け取る
        ename = EquipManager.EquipItemName();

        foreach(GameObject equipitem in EquipItems){
            //オブジェクト名と装備中のアイテム名が一致しなかったら非表示にする
            if(ename == null || equipitem.name != ename){
                equipitem.SetActive(false);
            }else{
                NowItems = equipitem;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //装備を変更したときに発動させる関数
    public static void ChangeEquipItem(){
        //現在装備中のアイテム名を受け取る
        ename = EquipManager.EquipItemName();
        foreach(GameObject equipitem in EquipItems){
            //Debug.Log(equipitem.name);
            //オブジェクト名と装備中のアイテム名が一致しなかったら非表示にする
            if(equipitem.name != ename){
                equipitem.SetActive(false);
            }else{
                NowItems = equipitem;
                NowItems.SetActive(true);
            }
        }
    }
}
