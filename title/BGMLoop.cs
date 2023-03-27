using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//bgmを滑らかに流すためのスクリプト
public class BGMLoop : MonoBehaviour
{
    public AudioSource bgmAudio;

    void Update()
    {
        if(bgmAudio.time >= 8.0f){
            bgmAudio.time = 1.0f;
            bgmAudio.Play();
        }
    }
}
