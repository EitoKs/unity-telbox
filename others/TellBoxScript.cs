using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TellBoxScript : MonoBehaviour
{
    [SerializeField]
    private Animator TellDoorAni;
    [SerializeField]
    private GameObject TransWallDoor;
    //ドアが開いているかどうかを判定
    public bool dooropen;

    //ドアの開閉音の音源
    public AudioSource doorAudio;

    //ドアを開閉するときの音
    public AudioClip doorOpenClip;
    public AudioClip doorClosenClip;


    //このスクリプトをインスタンス化しておいて他のスクリプトからも潜入できるようにする
    public static TellBoxScript instance;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        dooropen = false;
    }

    void Update()
    {
        
    }

    //扉が開いたときの処理をまとめた場所
    public void DoorOpen(){
        if(dooropen == false){
            //ドアが開くアニメーションを実行
            TellDoorAni.SetBool("dooropen", true);
            //ドアのコライダーをOnにして通れるようにする
            TransWallDoor.GetComponent<BoxCollider>().isTrigger = true;
            doorAudio.PlayOneShot(doorOpenClip);
            dooropen = true;
        }
    }

    //扉が閉じたときの処理をまとめた場所
    public void DoorClose(){
        if(dooropen == true){
            //ドアが閉じるアニメーションを実行
            TellDoorAni.SetBool("dooropen", false);
            //ドアのコライダーをOFFにして通れないようにする
            TransWallDoor.GetComponent<BoxCollider>().isTrigger = false;
            doorAudio.PlayOneShot(doorClosenClip);
            dooropen = false;
        }
    }
    //ドアが開いてるかどうかを返す関数
    //trueならドアが開いている
    public bool OpenClose(){
        return dooropen;
    }
}