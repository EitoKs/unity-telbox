using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//タイトル画面の「はじめる」ボタンのテキストの色を変えるスクリプト
public class Textcolorchanger : MonoBehaviour
{
    [SerializeField]
    private Animator textAnimator;
    private bool change_color;
    //private bool text_click;

    void Start(){
        change_color = false;
        //text_click = false;
    }

    //マウスカーソルが乗ったときテキストの色を変える(赤色)
    public void TextColorChangeOn(){
        if(change_color == false){
            change_color = true;
            textAnimator.SetBool("changecolor", change_color);
        }
    }

    //カーソルが乗っていないときのテキストの色をもとに戻す（白色）
    public void TextColorChangeOff(){
        if(change_color == true){
            change_color = false;
            textAnimator.SetBool("changecolor", change_color);
        }
    }

    public void TextClick(){
        textAnimator.SetBool("textclick", true);
    }
}
