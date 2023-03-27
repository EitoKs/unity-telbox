using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

//インベントリ画面に表示されているオブジェクトに対するスクリプト
public class InventItem : MonoBehaviour
{
    //"InventItem"タグがついているオブジェクトを複数格納する変数
    private GameObject[] InventItems;
    //アイテム名格納用変数
    private string[] item_name;
    //アイテム名比較用
    private string iname;
    //現在表示中のオブジェクトを格納する変数
    public static GameObject[] NowItems = new GameObject[4];
    //何番目のアイテムかを管理する変数
    private int num;
    //操作を実行するオブジェクトを格納する変数
    public static GameObject Nowitem;
    //今何かしら装備をしているかを判定する変数
    public bool EquipTriger;
    //装備している場所を管理する変数
    public int EquipNum;

    void Start()
    {
        //今、何かしら装備しているか確かめる
        EquipTriger = EquipManager.EquipJudge();
        //装備している状態ならば
        if(EquipTriger == true){
            //今、何番目のアイテムを装備しているかを確かめる
            EquipNum = EquipManager.EquipNum();
        }
        //今注目しているアイテム番号を初期化
        num = 0;

        //表示する用のアイテム配列を空にしておく
        for(int i=0; i<4; i++){
            NowItems[i] = null;
        }
        //"InventItem"タグがついているオブジェクトをすべて入れる
        InventItems = GameObject.FindGameObjectsWithTag("InventItem");
        //アイテムをすべて表示する
        foreach(GameObject Items in InventItems){
            Items.SetActive(true);
        }
         //アイテム名を格納した配列を取得(これで現在入手しているアイテムを取得)
        item_name = ItemManager.SendItemData();
        
        //入手しているアイテム名でループさせる
        foreach(string iname in item_name){
            //アイテムがあるなら
            if(iname != null){
                //変数に見つけたアイテム名と一致するアイテムを格納する
                GameObject inventitem = GameObject.Find(iname);
                //今手に入れているアイテムオブジェクトの配列に入れておく
                NowItems[num] = inventitem;
                //カウントを増やしておく
                num++;
            }
        }

        //アイテムをすべて非表示にしておく
        foreach(GameObject Items in InventItems){
            Items.SetActive(false);
        }

        //アイテムが空じゃなければ
        if(NowItems != null){
            //手に入れたアイテムをループさせる
            for(int i=0; i<NowItems.Length; i++){
                //もしアイテムが入っていたら
                if(NowItems[i] != null){
                    //入手したアイテムを表示する
                    NowItems[i].SetActive(true);
                    //もし何かしら装備をしているならば
                    if(EquipTriger == true){
                        //ｚ軸用の変数
                        int z_value = Mathf.Abs(EquipNum - i);
                        //入手順によって位置を変える
                        NowItems[i].transform.position += new Vector3(3*(i-EquipNum), 0, 1*z_value);
                    //何も入手していなかったら
                    }else{
                        //入手順によって位置を変える
                        NowItems[i].transform.position += new Vector3(3*i, 0, 1*i);
                    }
                }
            }
        }
        //タグが付いているオブジェクトでループさせる
        // foreach(GameObject inventitem in InventItems){
        //     //Debug.Log(inventitem.name);
        //     //タグ付きオブジェクトのアイテム名を格納
        //     iname = inventitem.name;
        //     //何もアイテムを手に入れていなければすべて非表示
        //     if(item_name != null || item_name.Length != 0){
        //         //はじめに非表示にしておく
        //         inventitem.SetActive(false);
        //         //入手しているアイテム一覧とすべてのアイテムを照合していく
        //         foreach(string Iname in item_name){
        //             //名前が一致したら中身を実行
        //             if(iname == Iname){
        //                 //入手したアイテムを表示する
        //                 inventitem.SetActive(true);
        //                 //入手順によって位置を変える
        //                 inventitem.transform.position += new Vector3(3*num, 0, 1*num);
        //                 //今手に入れているアイテムオブジェクトの配列に入れておく
        //                 NowItems[num] = inventitem;
        //                 //カウントを増やしておく
        //                 num++;
        //             }
        //         }
        //     }else{
        //         inventitem.SetActive(false);
        //     } 
        // }
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject inventItem in InventItems){
            inventItem.transform.Rotate(new Vector3(0, 1, 0));
        }
    }

    //オブジェクト全体を右にスライド移動させる
    public static void RightSlide(int Now_num, int NowItemNum){
        //一番最初の要素のときもしくはアイテムがないとき発動しない
        if(NowItemNum != 0 && Now_num != 0){
            //今見つかっているアイテム数文の繰り返し処理
            for(int i=0; i<NowItemNum; i++){
                //変数にi番目に手に入れたアイテム（オブジェクト）を入れる
                Nowitem = NowItems[i];
                //選択しているアイテムより右側にあるアイテムの処理
                if(i >= Now_num){
                    //x方向に3,z方向に1移動する
                    Nowitem.transform.position += new Vector3(3.0f, 0, 1.0f);
                }else{  //選択しているアイテムより左側にあるアイテムの処理
                    //x方向に3,z方向に-1移動する
                    Nowitem.transform.position += new Vector3(3.0f, 0, -1.0f);
                }
            }
            //こっちだと要素がない（null）もオブジェクトとして扱われてエラーで止まる
            // foreach(GameObject Nowitem in NowItems){
            //     //now_numに各アイテムの番号を格納
            //     int now_num = Array.IndexOf(NowItems, Nowitem);
            //     //選択しているアイテムより右側にあるアイテムの処理
            //     if(now_num >= Now_num){
            //         //x方向に3,z方向に1移動する
            //         Nowitem.transform.position += new Vector3(3.0f, 0, 1.0f);
            //     }else{  //選択しているアイテムより左側にあるアイテムの処理
            //         //x方向に3,z方向に-1移動する
            //         Nowitem.transform.position += new Vector3(3.0f, 0, -1.0f);
            //     }
            // }
        }
    }

    //オブジェクト全体を左にスライド移動させる
    public static void LeftSlide(int Now_num, int NowItemNum){
        //一番最後の要素のときもしくはアイテムがないとき発動しない
        if(NowItemNum != 0 && Now_num < (NowItemNum - 1)){
            for(int i=0; i<NowItemNum; i++){
                Nowitem = NowItems[i];
                //選択しているアイテムより右側にあるアイテムの処理
                if(i <= Now_num){
                    //x方向に3,z方向に1移動する
                    Nowitem.transform.position += new Vector3(-3.0f, 0, 1.0f);
                }else{  //選択しているアイテムより左側にあるアイテムの処理
                    //x方向に3,z方向に-1移動する
                    Nowitem.transform.position += new Vector3(-3.0f, 0, -1.0f);
                }
            }
            //こっちだと要素がない（null）もオブジェクトとして扱われてエラーで止まる
            // foreach(GameObject Nowitem in NowItems){
            //     //now_numに各アイテムの番号を格納
            //     int now_num = Array.IndexOf(NowItems, Nowitem);
            //     //選択しているアイテムより左側にあるアイテムの処理
            //     if(now_num <= Now_num){
            //         //x方向に-3,z方向に-1移動する
            //         Nowitem.transform.position += new Vector3(-3.0f, 0, 1.0f);
            //     }else{  //選択しているアイテムより左側にあるアイテムの処理
            //         //x方向に-3,z方向に1移動する
            //         Nowitem.transform.position += new Vector3(-3.0f, 0, -1.0f);
            //     }
            // }
        }
    }
}
