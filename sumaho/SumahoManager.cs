using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//スマホ画面のノベル画面の操作をまとめたスクリプト
public class SumahoManager : MonoBehaviour
{
    //チャットのオブジェクトを管理するオブジェクト
    [SerializeField]
    private RectTransform content;

    //自分のチャット画面を出すためのプレハブ
    [SerializeField]
    private RectTransform MyChatNodePrefab;

    //相手側のチャットを出す為のプレハブ
    [SerializeField]
    private RectTransform OtherChatNodePrefab;

    //自分のチャットの文章が書いてあるText
    [SerializeField]
    private Text mychatText;
    //自分の名前を入れる場所
    [SerializeField]
    private Text myName;
    //相手のチャットの文章が書いてあるText
    [SerializeField]
    private Text otherchatText;
    //相手の名前を入れる場所
    [SerializeField]
    private Text otherName;

    [SerializeField]
    private ScrollRect _ScrollRect;

    //上に表示している名前のテキスト
    [SerializeField]
    private Text UpperName;

    public static string upper_name;

    public static string[] chattext;
    //public static bool[] myother;
    public static int[] myother;

    //マウスホイールの値を入れる変数を宣言
    private float scroll;

    private float content_y;
    //private float content_height;

    //メッセージが出た時の効果音
    public AudioClip sumaho;
    //このスクリプトのインスタンスを入れる変数
	//public static SumahoManager SumahoManager_instance;

    void Awake(){
        MyChatNodePrefab.gameObject.SetActive(false);
        OtherChatNodePrefab.gameObject.SetActive(false);
    }

    void Start()
    {
        UpperName.text = upper_name;
        //文章を表示させるコルーチンを実行する
        StartCoroutine(ChatText(chattext, myother));
        content_y = content.GetComponent<RectTransform>().anchoredPosition.y;
        //content_height = content.GetComponent<RectTransform>().sizeDelta.y;
    }

    void Update(){
        //スクロール操作を可能にするため
        WheelCon();
        //ホイールを上方向に回すと上をさかのぼれる
        if ((scroll > 0)&& content_y >= 0)
        {
            if(content_y > 10){
                content.GetComponent<RectTransform>().anchoredPosition -= new Vector2(0,10);
            }else{
                content.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,0);
            }
            content_y = content.GetComponent<RectTransform>().anchoredPosition.y;
        }else if((scroll < 0)){     //ホイールを下方向に回すと下をさかのぼる
            content.GetComponent<RectTransform>().anchoredPosition += new Vector2(0,10);
            content_y = content.GetComponent<RectTransform>().anchoredPosition.y;
        }else if(Input.GetKeyDown ("w") && content_y >= 0){     //ｗキーを押したとき上にさかのぼる
            if(content_y > 20){
                content.GetComponent<RectTransform>().anchoredPosition -= new Vector2(0,20);
            }else{
                content.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,0);
            }
            content_y = content.GetComponent<RectTransform>().anchoredPosition.y;
        }else if(Input.GetKeyDown ("s")){   //Sキーを押したとき下にさかのぼる
            content.GetComponent<RectTransform>().anchoredPosition += new Vector2(0,20);
            content_y = content.GetComponent<RectTransform>().anchoredPosition.y;
        }
    }

    //マウスホイールをどっちに動かしたかを判定する関数
    void WheelCon(){
        //マウスホイールの値を入れる変数を0で初期化
        scroll = 0;
        //マウスのホイールの操作を上の変数に代入
        scroll = Input.GetAxis("Mouse ScrollWheel");
    }

    // クリック待ちのコルーチン
    IEnumerator SumahoSkip()
    {
        //1フレーム待たなければ2回分進んでしまう
        yield return null;
        //クリックされたとき待機させておく
        while(true){
            //dキーを押すと読み進める
            if(Input.GetKeyDown ("d")){
                break;  //コルーチンを終了
            }else{
                yield return null;  //1フレーム待つ
            }
        }
    }

    IEnumerator ChatText(string[] Chat_Text, int[] MyOther){
        for(int i=0; i < Chat_Text.Length; i++){
            DrawChatText(Chat_Text[i], MyOther[i]);     //ここで文字を表示させる
            Debug.Log(i);
            yield return StartCoroutine("SumahoSkip");
            content_y = content.GetComponent<RectTransform>().anchoredPosition.y;
            //content_height = content.GetComponent<RectTransform>().sizeDelta.y;
        }
        SumahoScript.Sumaho_instance.SumahoClose();
    }

    public void DrawChatText(string text, int myother){
        StartCoroutine(CoDrawChatText(text, myother));
    }

    IEnumerator CoDrawChatText(string text, int myother){
        if(myother == 0){    //自分のだったとき
            mychatText.text = text;
            myName.text = "しんじ";
            var element = GameObject.Instantiate<RectTransform> (MyChatNodePrefab);
            element.SetParent(content, false);
            element.SetAsLastSibling();     //上詰めで設置
            element.gameObject.SetActive (true);
        }else if(myother == 1){      //相手のメッセージだった時
            otherchatText.text = text;
            otherName.text = "やすし";
            var element = GameObject.Instantiate<RectTransform> (OtherChatNodePrefab);
            element.SetParent(content, false);
            element.SetAsLastSibling();
            element.gameObject.SetActive (true);
        }else if(myother == 2){

        }
        AudioManager.instance.AudioOn(sumaho);
        //1フレーム停止
        yield return null;
        _ScrollRect.verticalNormalizedPosition = 0.0f;
    }
}
