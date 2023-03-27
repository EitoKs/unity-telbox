using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour
{
    //カーソルを管理するためのスクリプト
    //カーソルをロックする関数
    public static void CursorLock(){
        // カーソルロックをする
        Cursor.lockState = CursorLockMode.Locked;
        //カーソルを非表示にする
        Cursor.visible = false;
    }
//------------------------------------------------

    //カーソルを自由に動かせる関数(ロック解除)
    public static void CursorFree(){
        // カーソルロックを解除
        Cursor.lockState = CursorLockMode.None;
        //カーソルを表示する
        Cursor.visible = true;
    }
}
