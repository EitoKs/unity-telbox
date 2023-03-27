using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//公衆電話のライトをつけたり消したりするスクリプト
public class TellRight : MonoBehaviour
{
    //電話ボックスのライトのオンオフに関わるオブジェクト
    [SerializeField]
    private GameObject blackwindow01;
    [SerializeField]
    private GameObject blackwindow02;
    [SerializeField]
    private GameObject blackwindow03;
    [SerializeField]
    private GameObject blackwindow04;
    [SerializeField]
    private GameObject blackwindow05;
    [SerializeField]
    private GameObject tell_light;
    
    //ライトがチカチカさせる演出をしているかしていないかを判定
    private bool lightchika;
    //ライトがチカチカする演出を止める
    public bool lightkeep;
    //このスクリプトのインスタンス
    public static TellRight instance;
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
    	{
        	instance = this;
    	}
        lightchika = false;
        lightkeep = false;
    }

    // Update is called once per frame
    void Update()
    {
        //通常は点滅させておくが、電話に近づいた以降はつけっぱにしておく
        if(lightkeep == false){
            LightChika();
        }
    }

    //公衆電話のライトをつける
    public void LightUp(){
        blackwindow01.SetActive(false);
        blackwindow02.SetActive(false);
        blackwindow03.SetActive(false);
        blackwindow04.SetActive(false);
        blackwindow05.SetActive(false);
        tell_light.SetActive(true);
    }
    //公衆電話のライトを消す
    public void LightDown(){
        blackwindow01.SetActive(true);
        blackwindow02.SetActive(true);
        blackwindow03.SetActive(true);
        blackwindow04.SetActive(true);
        blackwindow05.SetActive(true);
        tell_light.SetActive(false);
    }

    //ライトをチカチカさせる関数
    public void LightChika(){
        if(lightchika == false){
            lightchika = true;
            StartCoroutine(LightCling());
        }
    }

    //ライトをチカチカさせるコルーチン
    private IEnumerator LightCling(){
        LightUp();
        yield return new WaitForSeconds(2.0f);
        LightDown();
        yield return new WaitForSeconds(0.3f);
        LightUp();
        yield return new WaitForSeconds(0.1f);
        LightDown();
        yield return new WaitForSeconds(0.1f);
        LightUp();
        lightchika = false;
    }

    public void LightKeep(){
        lightkeep = true;   //つけっぱにしておく
        LightUp();
    }
}
