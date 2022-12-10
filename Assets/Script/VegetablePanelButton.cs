using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VegetablePanelButton : MonoBehaviour
{
    [SerializeField] GameObject vegetablePanel;
    [SerializeField] GameObject happaButton;
    [SerializeField] GameObject playerAction;
    [SerializeField] GameObject vegetableInformation;
    [SerializeField] AudioSource audioSource;

    private PlayerAction playerActionCs;
    private VegetableInformation vegetableInformationCs;
    private GameObject bgm;
    private AudioSource bgm_audiosource;

    public AudioClip heart;
    public bool happaflg = true;
    private bool happaBreakflg = false;
    private void Awake()
    {
        playerActionCs = playerAction.GetComponent<PlayerAction>();
        vegetableInformationCs = vegetableInformation.GetComponent<VegetableInformation>();
        bgm = GameObject.Find("BGM");
        bgm_audiosource = bgm.GetComponent<AudioSource>();
    }
    public void PushYesButton()
    {
        SceneManager.LoadScene("Result");
    }

    public void PushNoButton()
    {
        vegetablePanel.SetActive(false);
        playerActionCs.clicked = false;
    }

    public void PushHappaButton()
    {
        if (playerActionCs.decideNum == vegetableInformationCs.fakerNumber)
        {
            bgm_audiosource.Stop();
            happaBreakflg = true;
            audioSource.PlayOneShot(heart);
            Destroy(happaButton,3);
        }
        else
        Destroy(happaButton);  
    }

    private void OnDestroy()
    {
        if(happaBreakflg == true)
        bgm_audiosource.Play();
    }
}
