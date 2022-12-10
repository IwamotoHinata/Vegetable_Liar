using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    public int answerNum;//�U���̔ԍ����i�[
    public int selectNum;//�I��������؂̔ԍ����i�[
    [SerializeField] GameObject playerAction;
    [SerializeField] GameObject vegetableInformation;
    private PlayerAction playerActionCs;
    private VegetableInformation vegetableInformationCs;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        playerActionCs = playerAction.GetComponent<PlayerAction>();
        vegetableInformationCs = vegetableInformation.GetComponent<VegetableInformation>();
    }

    // Update is called once per frame
    void Update()
    {
        selectNum = playerActionCs.decideNum;
        answerNum = vegetableInformationCs.fakerNumber;
    }
}
