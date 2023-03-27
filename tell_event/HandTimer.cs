using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTimer : MonoBehaviour
{
    //手のオブジェクトを格納する配列
    public GameObject[] handArray;
    public AudioSource handAudio;

    public static HandTimer instance;

    // Start is called before the first frame update
    void Start()
    {
        //インスタンスを作り、別のファイルでも関数を使えるようにする
		if(instance == null)
    	{
        	instance = this;
    	}
        
        //配列内のオブジェクトをすべて非表示にする
        for(int i=0; i < handArray.Length; i++){
            handArray[i].SetActive(false);
        }
    }

    public void OneHandShow(int num){
        handArray[num].SetActive(true);
        handAudio = handArray[num].GetComponent<AudioSource>();
        handAudio.PlayOneShot(handAudio.clip);
    }
}
