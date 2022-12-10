using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolPanelButton : MonoBehaviour
{
    [SerializeField] GameObject ToolPanel;
    [SerializeField] GameObject Button_no;
    [SerializeField] GameObject playerAction;
    [SerializeField] GameObject vegetableInformation;
    [SerializeField] AudioSource audioSource;
    private PlayerAction playerActionCs;
    private VegetableInformation vegetableInformationCs;

    private GameObject bgm;
    private AudioSource bgm_audiosource;
    /*銃の為のSE*/
    public AudioClip gunshot;
    public AudioClip scream;
    /*スマホの為のSE,BGM*/
    public AudioClip music;
    public AudioClip clap;


    private void Awake()
    {
        bgm = GameObject.Find("BGM");
        bgm_audiosource = bgm.GetComponent <AudioSource> ();
    }

    public void YesButton()
    {
        playerActionCs = playerAction.GetComponent<PlayerAction>();
        vegetableInformationCs = vegetableInformation.GetComponent<VegetableInformation>();

        if (playerActionCs.useflg == true)
        {
            switch (playerActionCs.decideNum)
            {
                case 6:
                    StartCoroutine("pistol");

                    break;
                case 7:
                    StartCoroutine("smartphone");
                    break;
                default: break;
            }
            playerActionCs.useflg = false;
            Button_no.SetActive(false);
        }
    }

    public void NoButton()
    {
            playerActionCs = playerAction.GetComponent<PlayerAction>();
            playerActionCs.clicked = false;
            ToolPanel.SetActive(false);
    }

    IEnumerator pistol()
    {
        Debug.Log("ピストル");
        yield return new WaitForSeconds(0f);
        {
            audioSource.PlayOneShot(gunshot);
        }
        
        yield return new WaitForSeconds(0.5f); //もし上段の野菜のうちに偽野菜があったら悲鳴を上げる
        { 
            if (0 <= vegetableInformationCs.fakerNumber && vegetableInformationCs.fakerNumber <= 2)
            {
                audioSource.PlayOneShot(scream);
                yield return new WaitForSeconds(2f);
                {
                    playerActionCs.clicked = false;
                    ToolPanel.SetActive(false);
                }
            }
            playerActionCs.clicked = false;
            ToolPanel.SetActive(false);
        }
        
    }
    IEnumerator smartphone()
    {
        Debug.Log("スマホ");
        //音楽を再生した後に下段の中に野菜があったら喝采
        yield return new WaitForSeconds(0f);
        {
            bgm_audiosource.Stop();
            audioSource.clip = music;
            audioSource.PlayOneShot(music);
        }
        yield return new WaitForSeconds(13f);
        { 
            if (3 <= vegetableInformationCs.fakerNumber && vegetableInformationCs.fakerNumber <= 5)
            {
                audioSource.PlayOneShot(clap);
                yield return new WaitForSeconds(4.5f);
                {
                    bgm_audiosource.Play();
                    playerActionCs.clicked = false;
                    ToolPanel.SetActive(false);
                }
            }
            bgm_audiosource.Play();
            playerActionCs.clicked = false;
            ToolPanel.SetActive(false);
        }
   
    }
}
