using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//このスクリプトがくっついているオブジェクトを調べたときに
//ここに書いてあるテキスト文章を表示させるスクリプト
//文章の内容はインスペクター画面から入力
//主にアイテムやオブジェクトにくっつける
//汎用性を意識して制作した
public class ObjectText : MonoBehaviour
{
    //これらの変数はインスペクター画面から設定する
    //------------------------------------------
    //これらでどのテキストイベントなのかを区別
    public int ObjectID;   //０ならオブジェクト、１ならアイテムの処理をする

    //すでに１度、調べたかどうかを判定
    public bool isSearch;

    //カーソルを合わせたときに表示するオブジェクト名テキスト
    public string object_name;

    //表示させる文章を格納する（表示する文章は１要素）
    public string[] text_string;
    //誰が話しているかを判別
    public int[] text_name;

    //-------------------------------------------
    //この部分でテキストを表示させる
    //ItemPiker.csで呼び出す
    public void ShowTextString(){
        NovelScript.Novel_instance.NovelUIOpen(text_string, text_name);     //文章を表示
        isSearch = true;    //一度、調べた判定にする
    }
}
