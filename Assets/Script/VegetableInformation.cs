using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VegetableInformation : MonoBehaviour
{
    public int[] weight;
    public int fakerNumber;//�����ɉ����ċU���Ɂi0:�u���b�R���[ �E�E�E�j
    public Text[] weightText;
    // Start is called before the first frame update
    void Start()
    {
        Random.InitState(System.DateTime.Now.Millisecond);//�����_���ɂ��邽�߂̐錾
        weight = new int[6];

        weight[0] = 300 + Random.Range(1, 51);//�u���b�R���[
        weight[1] = 1000 + Random.Range(1, 51);//�L���x�c
        weight[2] = 200 + Random.Range(1, 51);//�ʂ˂�
        weight[3] = 150 + Random.Range(1, 51);//�W���K�C��
        weight[4] = 1200 + Random.Range(1, 51);//�J�{�`��
        weight[5] = 150 + Random.Range(1, 51);//�g�}�g

        //��i�̖�؂̂����A��ȊO�̑S�Ă��d������
        int random1 = Random.Range(1, 4);
        switch (random1)
        {
            case 1:
                weight[1] += 1000;
                weight[2] += 1000;
                break;
            case 2:
                weight[0] += 1000;
                weight[2] += 1000;
                break;
            case 3:
                weight[0] += 1000;
                weight[1] += 1000;
                break;
        }

        //���i�̖�؂̂����A��ȊO�̑S�Ă��d������
        int random2 = Random.Range(4, 7);
        switch (random2)
        {
            case 4:
                weight[4] += 1000;
                weight[5] += 1000;
                break;
            case 5:
                weight[3] += 1000;
                weight[5] += 1000;
                break;
            case 6:
                weight[3] += 1000;
                weight[4] += 1000;
                break;
        }

        //�ŏI�I�ȏd�����e�L�X�g�ɓ����
        for (int i = 0; i < 6; i++)
        { 
            weightText[i].text = "�d���F" + weight[i].ToString("0") + "g";
        }

        //�d���Ȃ�����؂̒�����1���U���Ƃ���
        if (random1 == 1)
        {
            if (random2 == 4)
            {
                switch (Random.Range(1, 101) % 4)
                {
                    case 0:
                        fakerNumber = 1;
                        break;
                    case 1:
                        fakerNumber = 2;
                        break;
                    case 2:
                        fakerNumber = 4;
                        break;
                    case 3:
                        fakerNumber = 5;
                        break;
                }
            }
            if (random2 == 5)
            {
                switch (Random.Range(1, 101) % 4)
                {
                    case 0:
                        fakerNumber = 1;
                        break;
                    case 1:
                        fakerNumber = 2;
                        break;
                    case 2:
                        fakerNumber = 3;
                        break;
                    case 3:
                        fakerNumber = 5;
                        break;
                }
            }
            if (random2 == 6)
            {
                switch (Random.Range(1, 101) % 4)
                {
                    case 0:
                        fakerNumber = 1;
                        break;
                    case 1:
                        fakerNumber = 2;
                        break;
                    case 2:
                        fakerNumber = 3;
                        break;
                    case 3:
                        fakerNumber = 4;
                        break;
                }
            }
        }

        if (random1 == 2)
        {
            if (random2 == 4)
            {
                switch (Random.Range(1, 101) % 4)
                {
                    case 0:
                        fakerNumber = 0;
                        break;
                    case 1:
                        fakerNumber = 2;
                        break;
                    case 2:
                        fakerNumber = 4;
                        break;
                    case 3:
                        fakerNumber = 5;
                        break;
                }
            }
            if (random2 == 5)
            {
                switch (Random.Range(1, 101) % 4)
                {
                    case 0:
                        fakerNumber = 0;
                        break;
                    case 1:
                        fakerNumber = 2;
                        break;
                    case 2:
                        fakerNumber = 3;
                        break;
                    case 3:
                        fakerNumber = 5;
                        break;
                }
            }
            if (random2 == 6)
            {
                switch (Random.Range(1, 101) % 4)
                {
                    case 0:
                        fakerNumber = 0;
                        break;
                    case 1:
                        fakerNumber = 2;
                        break;
                    case 2:
                        fakerNumber = 3;
                        break;
                    case 3:
                        fakerNumber = 4;
                        break;
                }
            }
        }

        if (random1 == 3)
        {
            if (random2 == 4)
            {
                switch (Random.Range(1, 101) % 4)
                {
                    case 0:
                        fakerNumber = 0;
                        break;
                    case 1:
                        fakerNumber = 1;
                        break;
                    case 2:
                        fakerNumber = 4;
                        break;
                    case 3:
                        fakerNumber = 5;
                        break;
                }
            }
            if (random2 == 5)
            {
                switch (Random.Range(1, 101) % 4)
                {
                    case 0:
                        fakerNumber = 0;
                        break;
                    case 1:
                        fakerNumber = 1;
                        break;
                    case 2:
                        fakerNumber = 3;
                        break;
                    case 3:
                        fakerNumber = 5;
                        break;
                }
            }
            if (random2 == 6)
            {
                switch (Random.Range(1, 101) % 4)
                {
                    case 0:
                        fakerNumber = 0;
                        break;
                    case 1:
                        fakerNumber = 1;
                        break;
                    case 2:
                        fakerNumber = 3;
                        break;
                    case 3:
                        fakerNumber = 4;
                        break;
                }
            }
        }
    }
    
}
