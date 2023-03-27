using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeController : MonoBehaviour
{
    //フェードイン/アウトをするためのUIのプレハブとインスタンスを入れるための変数
    [SerializeField]
    private GameObject FadeinUI;
    private GameObject FadeinUIInstance;

    [SerializeField]
    private GameObject FadeoutUI;
    private GameObject FadeoutUIInstance;
//--------------------------------------------------------------------------
    //フェードイン開始の処理
    public void Startfadein(){
        FadeinUIInstance = GameObject.Instantiate (FadeinUI) as GameObject;
    }
    
    //フェードイン終了後の処理
    public void Endfadein(){
        Destroy(FadeinUIInstance);
    }

    //フェードアウト開始の処理
    public void Startfadeout(){
        FadeoutUIInstance = GameObject.Instantiate (FadeoutUI) as GameObject;
    }

    //フェードアウト終了後の処理
    public void Endfadeout(){
        Destroy(FadeoutUIInstance);
    }
}
