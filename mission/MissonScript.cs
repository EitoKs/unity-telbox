using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//次にやることを示したテキスト文章を表示し、消すところまで制御するスクリプト
//UIにくっつける
//テキストはプレハブ化しておいて、それ自体を呼び出すのは別のスクリプトで呼び出す
//右上から左の方向へ徐々にフェードインしながら表示させる
public class MissonScript : MonoBehaviour
{
    //やることを示したUI
    [SerializeField]
	private GameObject MissonUI;
    //やることリストを表示するテキスト
    [SerializeField]
    private TextMeshProUGUI missionText;
    //やることリストが表示された時の効果音
    [SerializeField]
    private AudioClip bellsound;

    //デバッグ用
    public string mtxt;

    void Start()
    {
        MissonUI.SetActive(false);   //UIを非表示
    }

    void Update(){
        //イベント中ならば非表示にしておく
        if(NowEventScript.EventJudge() == true){
            MissonUI.SetActive(false);   //UIを非表示
        }
        //デバッグ用
        if (Input.GetKeyDown ("l")){
            MissonUIShow(mtxt);
        }
    }

    //やることリストを表示するスクリプト
    public void MissonUIShow(string missontxt){
        if(MissonUI.activeSelf == false){       //表示されているかどうか
            MissonUI.SetActive(true);   //UIを表示
            missionText.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);      //アルファ値を0にしておく
            missionText.text = missontxt;   //引数の文章を代入
            SEManager.instance.AudioOn(bellsound);
            StartCoroutine("TextFadeIn");   //徐々に表示する処理を実行
        }
    }
    //徐々に表示して徐々に消えていく処理
    IEnumerator TextFadeIn(){
        for(int i=0; i<255; i++){
            missionText.color = missionText.color + new Color32(0,0,0,1);
            yield return new WaitForSeconds(1.0f/255.0f);
        }
        yield return new WaitForSeconds(1.0f);
        for(int i=0; i<255; i++){
            missionText.color = missionText.color - new Color32(0,0,0,1);
            yield return new WaitForSeconds(1.0f/255.0f);
        }
        MissonUI.SetActive(false);   //UIを非表示
    }
}
