using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//MainCamaraのAudioSourceにくっつけるスクリプト
//イベントのＢＧＭや効果音とかを流すためのAudio
public class AudioManager : MonoBehaviour
{
    //このスクリプトのインスタンスを入れる変数
	public static AudioManager instance;
    //MainCameraについてるAudioSourceを入れる
    AudioSource audioSource;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //インスタンスを作り、別のファイルでも関数を使えるようにする
		if(instance == null)
    	{
        	instance = this;
    	}
    }
    //効果音を鳴らすための関数（引数は鳴らしたい効果音）
    public void AudioOn(AudioClip sound){
        audioSource.PlayOneShot(sound);
    }
}
