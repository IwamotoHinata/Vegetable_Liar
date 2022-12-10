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

    public int decideNum;//�N���b�N�����Q�[���I�u�W�F�N�g�𔻒f���邽�߂̕ϐ�
    public bool clicked = false;//true�ɂȂ����瑼�̃I�u�W�F�N�g��I���ł��Ȃ��悤�ɂ���
    public bool useflg = true;//true�̂Ƃ��Ƀc�[�����g�p�\�Bfalse�̂Ƃ��͎g�p�s��
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //�N���b�N�����ꏊ�ɃI�u�W�F�N�g����������p�l����\��
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);


            if (clicked == false)
            {
                //��؂��N���b�N�����Ƃ�
                if (hit2d.transform.gameObject.tag == "Vegetable")
                {
                    //�I��������؂̖��O�ɉ����ăe�L�X�g��ς���
                    switch (hit2d.collider.gameObject.name)
                    {
                        case "broccoli":
                            vegetableText.text = "�u���b�R���[���U���ł����H";
                            decideNum = 0;
                            break;
                        case "kyabetu":
                            vegetableText.text = "�L���x�c���U���ł����H";
                            decideNum = 1;
                            break;
                        case "onion":
                            vegetableText.text = "���܂˂����U���ł����H";
                            decideNum = 2;
                            break;
                        case "potato":
                            vegetableText.text = "���Ⴊ�������U���ł����H";
                            decideNum = 3;
                            break;
                        case "squash":
                            vegetableText.text = "���ڂ��Ⴊ�U���ł����H";
                            decideNum = 4;
                            break;
                        case "tomato":
                            vegetableText.text = "�g�}�g���U���ł����H";
                            decideNum = 5;
                            break;
                        default: break;
                    }
                    vegetablePanel.SetActive(true);
                    toolPanel.SetActive(false);
                    bookPanel.SetActive(false);

                }
                else if (hit2d.transform.gameObject.tag == "Tool")//�q���g�p�A�C�e���i�e,�X�}�z�j���N���b�N�����Ƃ�
                {
                    if (useflg == true)
                    {
                        switch (hit2d.collider.gameObject.name)
                        {
                            case "pistol":
                                toolText.text = "�s�X�g�����g���܂����H";
                                decideNum = 6;
                                break;
                            case "smartphone":
                                toolText.text = "�X�}�z���g���܂����H";
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
