using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//アイテムの入手状況を管理するスクリプト（空のオブジェクトにつけておく）
public class ItemManager : MonoBehaviour
{
    //アイテム一覧
    private enum Item {
        Item1,
        懐中電灯,
        Item2
    };
    //アイテム取得判定の変数
    private bool getItem;
    //最大アイテム数
    private int item_number = 2;
    //アイテム入手判定（デバッグ用）
    [SerializeField]
    public bool[] itemFlags = new bool[2];
    //アイテム名格納用変数
    private string item_name;
    //入手アイテム数カウント用変数
    public static int count;
    //入手アイテム名格納用
    public static string[] GetItem = new string[2];


    //このスクリプトをインスタンス化しておいて他のスクリプトからも潜入できるようにする
    public static ItemManager instance;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    public void ItemGetIn(string item_namei){
            //switch文でアイテム名を判断
            //インスペクターからどのアイテムを入手したかわかる（デバッグ用）
            switch(item_namei){
                case "Item1":
                    itemFlags[(int)Item.Item1] = true;
                    break;
                case "Item2":
                    itemFlags[(int)Item.Item2] = true;
                    break;
                // case "Item3":
                //     itemFlags[(int)Item.Item3] = true;
                //     break;
                case "懐中電灯":
                    itemFlags[(int)Item.懐中電灯] = true;
                    break;
                default:
                    break;
            }
            //最大アイテムより小さかったら入手アイテムを配列に格納
            //アイテムは入手順に格納していく
            if(count < item_number){
                GetItem[count] = item_namei;
                count++;
            }
    }

    //アイテムの入手情報を送る関数
    public static string[] SendItemData(){
        return GetItem;
    }
    //現在の入手アイテム数を返す関数
    public static int SendItemCount(){
        return count;
    }
}
