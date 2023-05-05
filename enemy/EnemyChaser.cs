using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;
//敵がTargetを追いかけるスクリプト
public class EnemyChaser : MonoBehaviour
{
    public GameObject target;   //追いかける対象
    private NavMeshAgent agent;     //Enemyにくっついているコンポーネント
    public bool now_chaseing;
    //アニメーションを行うやつ
    [SerializeField]
    private Animator animator;
    //心臓音の音程を制御するオーディオミキサー
    [SerializeField]
    private AudioMixer runsoundmixer;
    //心臓音を入れるオーディオソース
    [SerializeField]
    private AudioSource audiosource;

    //音の大きさを操作するための変数
    private float audiovalue;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        now_chaseing = false;
        runsoundmixer.SetFloat("RunSound", 1.0f);
        audiosource.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        float distans = Vector3.Distance(this.transform.position, target.transform.position);
        //Debug.Log(distans);
        //現在、追いかけるイベントならばプレイヤーを追尾する
        if(EventRun.instance.NowRunEvent() == true){
            if(target){
                if(!audiosource.isPlaying){     //再生されていなければ再生
                    audiosource.Play();
                }
                agent.destination = target.transform.position;
                //追いかけてくる距離ならば追いかけてくるアニメーションをさせる
                if(distans >= 2.5f){
                    now_chaseing = true;
                    animator.SetBool("stop_runing", false);
                    animator.SetBool("start_runing", true);
                //プレイヤーとの距離が縮まったらアニメーションを止める
                }else{
                    animator.SetBool("start_runing", false);
                    animator.SetBool("stop_runing", true);
                    now_chaseing = false;
                }

                //距離に応じて心臓音の大きさと早さを変える
                if(distans < 15.0f){   //とりあえず聞こえる距離
                    audiovalue = 1.0f - distans/15.0f;      //近づくほど大きくなる(max:1 min:約0)
                    audiosource.volume = 0.5f + audiovalue/2.0f;    //ボリューム（max:1 min:0.5）
                    audiosource.pitch = 1.0f + audiovalue;      //音の速さ（max:2 min:1）
                    runsoundmixer.SetFloat("RunSound", 1.0f - audiovalue/2.0f);   //音程（max:1 min:0.5）
                }else {
                    audiosource.volume = 0.0f;
                }
            }   
        }
    }

    //void OnCollisionEnter(Collision collision){
    void OnTriggerEnter(Collider collision){
        if(collision.gameObject.tag == "Player" && EventRun.instance.NowRunEvent() == true){
            Debug.Log("コンティニュー画面に飛ぶ");
            audiosource.Stop();
            Continue.now_continue = true;       //現在コンティニュー画面であるとする
            Continue.instance.Continue_Pro();       //コンティニュー画面を出す処理を行う
        }
    }
}
