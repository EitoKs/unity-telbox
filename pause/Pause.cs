using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    //ボタン
	//再開ボタンを入れる
	[SerializeField]
    private GameObject reStartButton;
	//オプションボタンを入れる
	[SerializeField]
    private GameObject OptionButton;
	//タイトルに戻るボタンを入れる
	[SerializeField]
    private GameObject ExitButton;
    //タイトルに戻るパネルを入れる
	[SerializeField]
    private GameObject ExitPanel;
    //メニュー画面が表示されているかどうかを判定する変数
    public bool menu_triger = false;

    void Start(){
        //タイトルに戻るパネルを非表示
        ExitPanel.SetActive(false);
    }

    //再開ボタンを押したとき発動する関数
    public void RestartMove()
    {
        //デバッグ用
        Debug.Log("再開ボタンを押したよ");
        //PauseScript.cs内の関数ExitPauseを呼び出す
        PauseScript.Pause_instance.ExitPause();
    }

    //タイトルに戻るで「はい」を押したとき発動する関数（タイトル画面に戻る）
    public void ExitMove()
    {
        //デバッグ用
        Debug.Log("終了ボタンを押したよ");
        Destroy(this.gameObject);
        SceneManager.LoadScene("Title");
        //時間の流れを再開する
		Time.timeScale = 1f;
    }

    //終了ボタンを押したとき実行
    public void ExitPanelOpen(){
        ExitPanel.SetActive(true);      //タイトルに戻るパネルを表示
    }

    //タイトルに戻るとき「いいえ」を押したとき実行
    public void ExitPanelClose(){
        ExitPanel.SetActive(false);      //タイトルに戻るパネルを表示
    }
}
