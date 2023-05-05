using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//アイテムの入手状況を管理するスクリプト（空のオブジェクトにつけておく）
public class ItemManager : MonoBehaviour
{
    //アイテム一覧（インスペクター画面からアイテム名を登録）
    public string[] Item;
    //最大アイテム数
    private int item_number = 3;
    //アイテム入手判定（デバッグ用）
    public bool[] itemFlags;
    //入手アイテム数カウント用変数
    public int count;
    //入手アイテム名格納用
    public string[] GetItem;
    //アイテムを使ったかどうかを判定
    public bool[] useFlags; 


    //このスクリプトをインスタンス化しておいて他のスクリプトからも潜入できるようにする
    public static ItemManager instance;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    
    void Start()
    {
        count = 0;      //始めは何も入手していないためアイテム数を０にしておく
    }
    //アイテムを入手したときの処理
    public void ItemGetIn(string item_namei){
            //事前に登録しておいたアイテム名と入手したアイテム名を比較
            //インスペクターからはitemFlagsでどのアイテムを入手したかわかる（デバッグ用）
            for(int i=0; i<item_number; i++){
                if(item_namei == Item[i]){
                    itemFlags[i] = true;
                }
            }
    //-----------------------------------------------------------------
            //最大アイテムより小さかったら入手アイテムを配列に格納
            //アイテムは入手順に格納していく
            if(count < item_number){
                GetItem[count] = item_namei;    //入手したアイテムの名前を格納
                count++;        //カウントを1進める
            }
    }
    //-----------------------------------------------------------------
    //アイテムを使ったときの処理
    public void ItemUse(string item_namei){
        NewEquipManager.instance.EquipClose();
        //手に入れたアイテム内で使うものと一致するものはあるか判定
        for(int i=0; i<GetItem.Length; i++){
            if(item_namei == GetItem[i]){
                GetItem[i] = null;
            }
            //もし現在調べているアイテム欄が空なら
            if(GetItem[i] == null && i<GetItem.Length-1){
                GetItem[i] = GetItem[i+1];  //所持アイテム欄を詰める
                GetItem[i+1] = null;    //詰めた分、空にしておく
            }
        }
        //アイテムを使った判定にする
        for(int j=0; j<Item.Length; j++){
            if(item_namei == Item[j]){
                useFlags[j] = true;
            }
        }
        count--;    //所持アイテム数を減らす
    }

    // void Update(){
    //     if(Input.GetKeyDown ("k")){
    //         ItemUse("Item1");
    //     }
    // }
}
