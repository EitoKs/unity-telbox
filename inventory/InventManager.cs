using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventManager : MonoBehaviour
{
    //アイテム画面（インベントリ画面）の操作・表示に関するスクリプト

    //アイテム名を管理する変数
    [SerializeField]
    private Text Item_name;
    //アイテム画面が開かれているかどうかの判定
    private bool invent_triger;
    //アイテム数を管理する変数
    //[SerializeField]
    public int item_num;
    //入手アイテム名を管理する変数
    private string[] ItemName;
    //マウスホイールの値を入れる変数を宣言
    private float scroll;
    //現在何番目のアイテムを選択しているか管理する変数
    //[SerializeField]
    public int select_num;

    //現在装備しているアイテム名を入れる変数
    // public static string equip_item;
    public string equip_item;
    //現在装備しているアイテムが何番目のアイテムか管理する変数
    //public static int equip_num;
    public int equip_num;
    //現在何かしら装備しているか判定する変数
    // public static bool equip_judge;
    public bool equip_judge;
    //装備中のテキストを管理する変数
    [SerializeField]
    private Text Equipment_name;

    //このスクリプトをインスタンス化しておいて他のスクリプトからも潜入できるようにする
    public static InventManager instance;

    //はじめにアイテム入手情報を取得しておく
    void Start()
    {
        //このスクリプトをインスタンス化する
        if(instance == null)
        {
            instance = this;
        }
        //インベントリ画面が開かれているかどうかを判定する
        invent_triger = InventScript.InventJudg();
        //現在手に入れたアイテムの数を取得
        //item_num = ItemManager.SendItemCount();
        item_num = ItemManager.instance.count;
        //アイテム名を格納した配列を取得
        //ItemName = ItemManager.SendItemData();
        ItemName = ItemManager.instance.GetItem;


        //現在何かしら装備しているか受け取る
        // equip_judge = EquipManager.EquipJudge();
        equip_judge = NewEquipManager.instance.EquipJudge;
        //アイテムを装備していたら「装備中」のテキストを表示にする
        if(equip_judge == false){
            Equipment_name.enabled = false;
            //なにも装備していない場合、基準を０番目にしておく
            equip_num = 0;
        }else{
            Equipment_name.enabled = true;
            //基準を装備中のアイテムの場所にしておく
            equip_num = NewEquipManager.instance.equipNum;
            equip_item = NewEquipManager.instance.equipName;
        }
        //はじめに選択しているアイテムを装備状況から決める
        select_num = equip_num;


        //アイテムが1個以上でもあれば
        if(item_num >= 1) {
            //入手したアイテムの１個目のアイテム名を入れておく
            Item_name.GetComponent<Text>().text = ItemName[0];
        }else{
            //アイテムが１個も無ければ操作ができない
            Item_name.GetComponent<Text>().text = "なし";
            //アイテムがないため念のため非表示にしておく
            Equipment_name.enabled = false;
        }
    }

    void Update()
    {
        //インベントリ画面が開かれていれば
        if(invent_triger == true) {
            //アイテムが1個以上でもあれば
            if(item_num >= 1) {
                WheelCon();
                //dキーを押すもしくはマウスホイールを上にすると右側のアイテムを選択できる
		        if ((Input.GetKeyDown ("d")) || (scroll > 0)){
                    Debug.Log("Dキーを入力");
                    //現在の入手アイテム数より小さければ
                    if(select_num < item_num - 1){
                        //アイテムをスライド移動させる
                        InventItem.LeftSlide(select_num, item_num);
                        //Debug.Log("++前");
                        select_num++;
                        //Debug.Log("++後");
                        //何かしら装備していて移動後のアイテムの場所が装備中のアイテムと一緒だったら
                        if(equip_judge == true && select_num == equip_num){
                            //「装備中」のテキストを表示する
                            Equipment_name.enabled = true;
                        }else{
                            //「装備中」のテキストを非表示する
                            Equipment_name.enabled = false;                            
                        }
                    }
                }else if((Input.GetKeyDown ("a")) || (scroll < 0)){   //aキーを押すもしくはマウスホイールを下にすると左側のアイテムを選択できる
                    Debug.Log("Aキーを入力");
                    //０より大きければ減らせる
                    if(select_num > 0){
                        //アイテムをスライド移動させる
                        InventItem.RightSlide(select_num, item_num);
                        //Debug.Log("--前");
                        select_num--;
                        //Debug.Log("--後");
                        //移動後のアイテムの場所が装備中のアイテムと一緒だったら
                        if(equip_judge == true && select_num == equip_num){
                            //「装備中」のテキストを表示する
                            Equipment_name.enabled = true;
                        }else{
                            //「装備中」のテキストを非表示する
                            Equipment_name.enabled = false;                            
                        }
                    }
                //Wキーもしくはマウスのホイールキーで
                //選択中のアイテムを装備する
                }else if((Input.GetKeyDown ("w")) || Input.GetMouseButtonDown(2)){
                    Debug.Log("Wキーを入力");
                    //まだ何も装備していなかったら、選択中のアイテムを装備する
                    if(equip_judge == false){
                        //装備している状態にする
                        equip_judge = true;
                        //現在選択中のアイテム名（ItemName[select_num]）を変数に入れる
                        equip_item = ItemName[select_num];
                        //現在装備中のアイテムが何番目かを入れる
                        equip_num = select_num;
                        //「装備中」のテキストを表示する
                        Equipment_name.enabled = true;
                    //何かしら装備していたら
                    }else{
                        //現在選択しているアイテムが装備中のアイテムだったら
                        if(select_num == equip_num){
                            //装備している状態にする
                            equip_judge = false;
                            //現在選択中のアイテム（ItemName[select_num]）をリセット
                            equip_item = null;
                            //何番目かをリセット
                            equip_num = 0;
                            //「装備中」のテキストを非表示する
                            Equipment_name.enabled = false;
                        }else{ //選択しているアイテムを装備していなかったらそのアイテムを装備する
                            //装備している状態にする
                            equip_judge = true;
                            //現在選択中のアイテム名（ItemName[select_num]）を変数に入れる
                            equip_item = ItemName[select_num];
                            //現在装備中のアイテムが何番目かを入れる
                            equip_num = select_num;
                            //「装備中」のテキストを表示する
                            Equipment_name.enabled = true;
                        }
                    }
                }
                //選択しているアイテム名を表示
                Item_name.GetComponent<Text>().text = ItemName[select_num];
            }else{
                //アイテムが１個も無ければ操作ができない
                //Item_name.GetComponent<Text>().text = "なし";
            }
        }
    }

    //マウスホイールをどっちに動かしたかを判定する関数
    void WheelCon(){
        //マウスホイールの値を入れる変数を0で初期化
        scroll = 0;
        //マウスのホイールの操作を上の変数に代入
        scroll = Input.GetAxis("Mouse ScrollWheel");
    }

    //現在装備しているアイテム名を返す関数
    // public static string EquipItem(){
    //     return equip_item;
    // }

    //現在、装備をしているかどうかを返す関数
    // public static bool Equip_Judge(){
    //     return equip_judge;
    // }

    //現在、何番目のアイテムを装備しているか返す関数
    // public static int Equip_Num(){
    //     return equip_num;
    // }
}
