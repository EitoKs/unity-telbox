using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//次にやることを示したテキスト文章を表示し、消すところまで制御するスクリプト
//UIにくっつける
//テキストはプレハブ化しておいて、それ自体を呼び出すのは別のスクリプトで呼び出す
//右上から左の方向へ徐々にフェードインしながら表示させる
public class MissonText : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI missionText;

    void Start()
    {
        missionText.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        StartCoroutine("TextFadeIn");
    }

    IEnumerator TextFadeIn(){
        for(int i=0; i<255; i++){
            missionText.color = missionText.color + new Color32(0,0,0,1);
            yield return new WaitForSeconds(1.0f/255.0f);
        }
        yield return new WaitForSeconds(3.0f);
        for(int i=0; i<255; i++){
            missionText.color = missionText.color - new Color32(0,0,0,1);
            yield return new WaitForSeconds(1.0f/255.0f);
        }
        Destroy(this.gameObject);
    }
}
