using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//エンドに到達したか管理するスクリプト
public class EndManager : MonoBehaviour
{
    //どのエンドを通過したかを判定する
    public static bool[] end_num = new bool[2]; 
    //今のところ通過したエンド数
    public static int end_count;

    void Start(){
        Debug.Log(end_count);
        if(end_count == 0){
            end_count = 0;
        }
    }

    public void EndClear1(){    //エンド１を見たときの処理
        if(end_num[0] == false){
            end_num[0] = true;  //エンド１をクリアしたことにする
            end_count++;   //エンド数を追加
        }
    }
    
    public void EndClear2(){    //エンド２を見たときの処理
        if(end_num[1] == false){
            end_num[1] = true;  //エンド２をクリアしたことにする
            end_count++;   //エンド数を追加
        }
    }

    //エンド表示後タイトル画面に飛ばす
    public void GoTitle(){
        SceneManager.LoadSceneAsync("Title");
    }

}
