using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAction : MonoBehaviour
{
    [SerializeField] GameObject vegetablePanel;
    [SerializeField] Text vegetableText;
    [SerializeField] GameObject happaButton;

    [SerializeField] GameObject toolPanel;
    [SerializeField] Text toolText;

    [SerializeField] GameObject bookPanel;
    [SerializeField] Image book1;
    [SerializeField] Image book2;

    public int decideNum;//クリックしたゲームオブジェクトを判断するための変数
    public bool clicked = false;//trueになったら他のオブジェクトを選択できないようにする
    public bool useflg = true;//trueのときにツールが使用可能。falseのときは使用不可
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //クリックした場所にオブジェクトがあったらパネルを表示
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);


            if (clicked == false)
            {
                //野菜をクリックしたとき
                if (hit2d.transform.gameObject.tag == "Vegetable")
                {
                    //選択した野菜の名前に応じてテキストを変える
                    switch (hit2d.collider.gameObject.name)
                    {
                        case "broccoli":
                            vegetableText.text = "ブロッコリーが偽物ですか？";
                            decideNum = 0;
                            break;
                        case "kyabetu":
                            vegetableText.text = "キャベツが偽物ですか？";
                            decideNum = 1;
                            break;
                        case "onion":
                            vegetableText.text = "たまねぎが偽物ですか？";
                            decideNum = 2;
                            break;
                        case "potato":
                            vegetableText.text = "じゃがいもが偽物ですか？";
                            decideNum = 3;
                            break;
                        case "squash":
                            vegetableText.text = "かぼちゃが偽物ですか？";
                            decideNum = 4;
                            break;
                        case "tomato":
                            vegetableText.text = "トマトが偽物ですか？";
                            decideNum = 5;
                            break;
                        default: break;
                    }
                    vegetablePanel.SetActive(true);
                    toolPanel.SetActive(false);
                    bookPanel.SetActive(false);

                }
                else if (hit2d.transform.gameObject.tag == "Tool")//ヒント用アイテム（銃,スマホ）をクリックしたとき
                {
                    if (useflg == true)
                    {
                        switch (hit2d.collider.gameObject.name)
                        {
                            case "pistol":
                                toolText.text = "ピストルを使いますか？";
                                decideNum = 6;
                                break;
                            case "smartphone":
                                toolText.text = "スマホを使いますか？";
                                decideNum = 7;
                                break;
                            default: break;
                        }
                        toolPanel.SetActive(true);
                        vegetablePanel.SetActive(false);
                        bookPanel.SetActive(false);
                    }
                    else
                    {
                        switch (hit2d.collider.gameObject.name)
                        {
                            case "pistol":
                                decideNum = 6;
                                break;
                            case "smartphone":
                                decideNum = 7;
                                break;
                            default: break;
                        }
                    }
                    
                }
                else if (hit2d.transform.gameObject.tag == "Book")
                {
                    bookPanel.SetActive(true);
                    toolPanel.SetActive(false);
                    vegetablePanel.SetActive(false);
                    book1.enabled = true;
                    book2.enabled = false;
                }
            }

            if (hit2d)
                clicked = true;

            if ((decideNum == 6 || decideNum == 7) && useflg == false)
                clicked = false;
        }
    }
}
