using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//ゲームを落とすスクリプト
public class GameExit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ButtonExit()
    {
        Application.Quit();
    }
}
