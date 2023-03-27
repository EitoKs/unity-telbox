using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//敵がTargetを追いかけるスクリプト
public class EnemyChaser : MonoBehaviour
{
    public GameObject target;   //追いかける対象
    private NavMeshAgent agent;     //Enemyにくっついているコンポーネント

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //現在、追いかけるイベントならばプレイヤーを追尾する
        if(EventRun.instance.NowRunEvent() == true){
            if(target){
                agent.destination = target.transform.position;
            }   
        }
    }
}
