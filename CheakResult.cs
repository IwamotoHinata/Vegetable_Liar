using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
public class CheakResult : MonoBehaviour
{
    [SerializeField] GameObject restartButton;
    [SerializeField] GameObject vegetable;
    [SerializeField] GameObject smoke;
    [SerializeField] AudioSource audiosource;
    [SerializeField] Text text;


    public Sprite[] vegetableImage;//本物の野菜画像
    public Sprite[] fakeVegetableImage;//偽物の野菜画像

    private SpriteRenderer render;
    private VideoPlayer videoplayer;

    private GameObject data;
    private Data dataCs;

    public AudioClip clear;
    public AudioClip miss;
    public AudioClip bomb;

    // Start is called before the first frame update
    void Start()
    {
        data = GameObject.Find("Data");
        dataCs = data.GetComponent<Data>();
        render = vegetable.GetComponent<SpriteRenderer>();
        videoplayer = smoke.GetComponent<VideoPlayer>();

        
        render.sprite = vegetableImage[dataCs.selectNum];
       
        if (dataCs.selectNum == dataCs.answerNum)
            StartCoroutine("Clear");
        else if(dataCs.selectNum != dataCs.answerNum)
        StartCoroutine("Miss");
        Debug.Log("start");
    }

    IEnumerator Clear()
    {
        yield return new WaitForSeconds(0.5f);
        { 
            videoplayer.Play();
            audiosource.PlayOneShot(bomb);
        }
        
        yield return new WaitForSeconds(0.1f);
        render.sortingOrder = -1;
        yield return new WaitForSeconds(2.4f);
        {
            render.sprite = fakeVegetableImage[dataCs.answerNum];
            render.sortingOrder = 0;        }
        yield return new WaitForSeconds(0.5f);
        {
            Destroy(smoke);
            audiosource.PlayOneShot(clear);
            restartButton.SetActive(true);
            text.text = "ゲームクリア!";
        }
        
    }
    IEnumerator Miss()
    {
        yield return new WaitForSeconds(0.5f);
        { 
            videoplayer.Play();
            audiosource.PlayOneShot(bomb);
        }
        
        yield return new WaitForSeconds(0.1f);
        render.sortingOrder = -1;
        yield return new WaitForSeconds(2.4f);
        { 
            render.sortingOrder = 0;
        }
        yield return new WaitForSeconds(0.5f);
        {
            Destroy(smoke);
            audiosource.PlayOneShot(miss);
            restartButton.SetActive(true);
            text.text = "ゲームオーバー!";
        }

    }
}
