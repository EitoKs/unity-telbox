using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    //敵オブジェクトを入れる
    public GameObject EnemyModel;
    //敵オブジェクトの音源
    public AudioSource EnemyAudioSource;

    //トンネルで出現するときになる音（笑い声）
    public AudioClip TonAudioClip;

    public static EnemyScript instance;

    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //追いかける機能を停止させた状態で敵を出現させる
    //引数に位置座標の数値を入れる
    public void EnemyShow(int event_num){
        EnemyModel.SetActive(true);
        //電話ボックスに出現するとき
        if(event_num == 0){
            EnemyModel.transform.position = new Vector3(80.20645f, 0.1604001f, 60.13246f);
        //トンネルの真ん中あたりに来た時に出現するとき
        }else if(event_num == 1){
            EnemyModel.transform.position = new Vector3(26.5f, 0.0f, 23.0f);
            EnemyAudioSource.PlayOneShot(TonAudioClip);
        }else if(event_num == 2){
            //EnemyModel.transform.position = new Vector3(posx, posy, posz);
        }
    }

    public void EnemyDes(){
        EnemyModel.SetActive(false);
    }
}
