using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//アイテムやイベントをを取るための判定をするスクリプト（プレイヤーにつける）
public class ItemPicker : MonoBehaviour
{
    //カメラをインスペクターから設定できるように
    [SerializeField]
    private Camera targetCamera;
    //画面中央のポインターをインスペクターから設定
    [SerializeField]
    private GameObject pointer_image;
    //注目しているアイテムの名前テキスト（アイテム名やイベント名）
    [SerializeField]
    private Text Item_name_text;
    //入手を促すテキスト（[F]で入手・・・など）
    [SerializeField]
    private Text GetItem_text;
    //画面のポインタUI
    [SerializeField]
    private GameObject PointerCanvas;
    //アイテム名の後ろの背景を含めたUI
    [SerializeField]
    private GameObject ItemNameUI;
//---------------------------------------------------------------
    //アイテムを手に入れたか判定
    public static bool GetItem = false;
    //イベントを調べたか判定
    public static bool SearchEvent;
//---------------------------------------------------------------
    //手に入れたアイテム名を格納
    public static string Item_Name;

    //メニュー画面が開かれているかどうか
    public bool item_triger = false;
    //光線に当たったオブジェクトを格納する変数(ここにrayが当たった最新のオブジェクトが入る)
    public static GameObject HitObject;

    void Start()
    {
        Item_name_text.enabled = false;     //アイテム名は非表示にしておく
        GetItem_text.enabled = false;       //下に表示するテキストを非表示にしておく
    }

    void Update()
    {
        //もしイベント中だったら非表示にしておく
        if(NowEventScript.EventJudge() == true){
            PointerCanvas.SetActive(false);
        }else{
            PointerCanvas.SetActive(true);
        }

        GetItem = false;
        SearchEvent = false;

        item_triger = UIController.UIJudg();    //操作できない条件を受け取る
        if(item_triger == false){
            if(targetCamera) {
                RaycastHit hit;     //Rayが当たったオブジェクトの情報が格納
                //Rayが当たっていれば
                if(Physics.Raycast(targetCamera.ViewportPointToRay(new Vector2(0.5f, 0.5f)), out hit, 5f)){
                    //オブジェクトのTagを比較
                    //Tagが”Item”もしくは”Event”なら
                    if(hit.collider.CompareTag("Item") || hit.collider.CompareTag("Event") || hit.collider.CompareTag("Object")){
                        //HitObjectに当たったオブジェクトを格納
                        HitObject = hit.collider.gameObject;
//------------------------------------------------------------------------------
                        //画面中央のポインタの色をTagごとの色に変更
                        if(hit.collider.CompareTag("Item")){
                            //画面中央のポインターの色を赤色に変更
                            pointer_image.GetComponent<Image>().color = new Color(1.0f, 0, 0, 1.0f);
                        }else if(hit.collider.CompareTag("Event")){
                            //画面中央のポインターの色を青色に変更
                            pointer_image.GetComponent<Image>().color = new Color(0, 0, 1.0f, 1.0f);
                        }else if(hit.collider.CompareTag("Object")){
                            //画面中央のポインターの色を青色に変更
                            pointer_image.GetComponent<Image>().color = new Color(0, 1.0f, 0, 1.0f);
                        }
//-------------------------------------------------------------------------------
                        //ポインタの上と下に表示するテキスト文章をTagごとに変更し、表示
                        if(hit.collider.CompareTag("Item")){
                            //ポインタ上のTextに注目している名前を入れる
                            //Item_name_text.GetComponent<Text>().text = hit.collider.gameObject.name;
                            Item_name_text.GetComponent<Text>().text = hit.collider.GetComponent<ObjectText>().object_name;
                            GetItem_text.text = "[F]で入手";
                        }else if(hit.collider.CompareTag("Event")){
                            //ポインタ上のTextに注目している名前を入れる
                            Item_name_text.GetComponent<Text>().text = EventManagerS.instance.EventName(hit.collider.gameObject.name);
                            GetItem_text.text = "[F]で調べる";
                        }else if(hit.collider.CompareTag("Object")){
                            //オブジェクトの名前からオブジェクトの状態を受け取る
                            Item_name_text.GetComponent<Text>().text = ObjectManager.instance.ObjectStateName(hit.collider.gameObject.name);
                            //Item_name_text.GetComponent<Text>().text = hit.collider.GetComponent<ObjectText>().object_name;
                            GetItem_text.text = "[F]でアクション";
                        }
//-------------------------------------------------------------------------------
                        //アイテム名・イベント名を表示する
                        Item_name_text.enabled = true;
                        //下に表示する文字を表示にしておく
                        GetItem_text.enabled = true;
                        //アイテム名を含めたUIを表示
                        ItemNameUI.SetActive(true);
//-------------------------------------------------------------------------------
                        //Rayがあったている状態でFキーを押したときの処理
                        if(Input.GetKeyDown(KeyCode.F)){
                            Debug.Log("拾った");    //デバッグ用
                            //拾ったアイテム名を格納
                            Item_Name = hit.collider.gameObject.name;
                            Debug.Log(Item_Name);   //変数の中身確認用
                            if(hit.collider.CompareTag("Item")){
                                //アイテムを拾ったからTRUEにしておく
                                GetItem = true;
                                ItemManager.instance.ItemGetIn(Item_Name);
                                DestroyImmediate(hit.collider.gameObject);      //オブジェクトを削除してみる
                            }else if(hit.collider.CompareTag("Event")){
                                SearchEvent = true;     //イベントを調べたからTRUEにしておく
                                EventManagerS.instance.GetEventJudge(Item_Name);
                                //DestroyImmediate(hit.collider.gameObject);      //オブジェクトを削除してみる
                            }else if(hit.collider.CompareTag("Object")){
                                ObjectManager.instance.ObjectEvent(Item_Name);
                                hit.collider.GetComponent<ObjectText>().ShowTextString();
                            }
                            //当たっているオブジェクトを初期化する
                            HitObject = null;
                            Point_Out();    //関数を呼び出し
                        }
//-------------------------------------------------------------------------------
                    }else{
                        Point_Out();    //関数を呼び出し
                    }
                }else{
                    Point_Out();    //関数を呼び出し
                }
            }else{
                Point_Out();    //関数を呼び出し
            }
        }
    }

    //レイがアイテムから外れた時の処理
    void Point_Out(){
        //当たっているオブジェクトを初期化する
        HitObject = null;
        //アイテムに当たっていないときポインターを元の色（白）に戻す
        pointer_image.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        //下に表示する文字を非表示にしておく
        GetItem_text.enabled = false;
        //アイテム名を非表示にする
        Item_name_text.enabled = false;
        //アイテム名を含めたUIを表示
        ItemNameUI.SetActive(false);
    }

    //アイテムを手に入れたかどうかを返す関数
    public static bool GetItemJudg(){
        return GetItem;
    }

    //どのアイテムを手に入れたか返す関数
    public static string ItemName(){
        return Item_Name;
    }

    //イベントを調べるかを返す関数
    public static bool SearchEventJudg(){
        return SearchEvent;
    }

    //rayが当たっているオブジェクトを返す関数
    public static GameObject RayHitItem(){
        return HitObject;
    }
}
