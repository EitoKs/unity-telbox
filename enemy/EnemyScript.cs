using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    //敵オブジェクトを入れる
    public GameObject EnemyModel;
    //イベント用のコライダーの入っていないモデルを入れる
    public GameObject EnemyEventModel;

    //敵オブジェクトの音源
    public AudioSource EnemyAudioSource;

    //トンネルで出現するときになる音（笑い声）
    public AudioClip TonAudioClip;

    //敵がアニメーションを行うやつ
    [SerializeField]
    private Animator animator;
    //敵がアニメーションを行うやつ２
    [SerializeField]
    private Animator animator2;



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
        //EnemyModel.SetActive(true);
        //電話ボックスに出現するとき
        if(event_num == 0){
            EnemyModel.SetActive(true);
            EnemyModel.transform.position = new Vector3(80.20645f, 0.1604001f, 60.13246f);
            EnemyModel.transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
        //トンネルの真ん中あたりに来た時に出現するとき
        }else if(event_num == 1){
            EnemyModel.SetActive(true);
            EnemyModel.transform.position = new Vector3(26.5f, 0.0f, 23.0f);
            EnemyModel.transform.rotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
            EnemyAudioSource.PlayOneShot(TonAudioClip);
        //車の目の前に表れるとき(その１)
        }else if(event_num == 2){
            EnemyEventModel.SetActive(true);
            //EnemyModel.transform.position = new Vector3(posx, posy, posz);
            EnemyEventModel.transform.position = new Vector3(3.4f, 0.0f, 10.42f);
            EnemyEventModel.transform.rotation = Quaternion.Euler(0.0f, 68.0f, 0.0f);
        //車の目の前に表れるとき(その２)
        }else if(event_num == 3){
            EnemyEventModel.SetActive(true);
            EnemyEventModel.transform.position = new Vector3(6.5f, 0.0f, 12.88f);
            EnemyEventModel.transform.rotation = Quaternion.Euler(0.0f, 68.0f, 0.0f);
        //ダンスする位置に移動
        }else if(event_num == 4){
            EnemyEventModel.SetActive(true);
            //Transform enemytransform = EnemyEventModel.transform;
            //enemytransform.Translate (-7.79f, 0.0f, -3.5f, Space.World);
            EnemyEventModel.transform.position = new Vector3(-1.17f, 0.24f, 9.0f);
            EnemyEventModel.transform.rotation = Quaternion.Euler(0.0f, 68.0f, 0.0f);
        //車の後部座席に移動
        }else if(event_num == 5){
            EnemyEventModel.SetActive(true);
            EnemyEventModel.transform.position = new Vector3(12.57f, 0.1f, 13.26f);
            EnemyEventModel.transform.rotation = Quaternion.Euler(0.0f, 248.0f, 0.0f);
        }

    }

    public void EnemyDes(){
        if(EnemyModel.activeSelf == true){
            EnemyModel.SetActive(false);
        }

        if(EnemyEventModel.activeSelf == true){
            EnemyEventModel.SetActive(false);
        }
    }

    //ガばっていう動作をさせる
    //フロントガラスにバンってやるアニメーショントリガー
    public void EnemyCarEvent01(){
        if(animator2.GetBool("final_event") == false){
            animator2.SetBool("final_event", true);
        }else{
            animator2.SetBool("final_event", false);
        }
    }
}
