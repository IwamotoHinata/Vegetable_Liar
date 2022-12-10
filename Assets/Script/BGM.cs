using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGM : MonoBehaviour
{
    [SerializeField] AudioSource audiosource;//BGM—p

    public AudioClip title;
    public AudioClip main;

    private int music = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
         
        if (SceneManager.GetActiveScene().name == "Title")
        {
            if (music == 0)
            { 
                audiosource.clip = title;
                audiosource.Play();
                music++;
            }                
        }
            
        

        if (SceneManager.GetActiveScene().name == "Main")
        {
            if (music == 1)
            { 
                audiosource.clip = main;
                audiosource.Play();
                music++;
            }
        }

        if (SceneManager.GetActiveScene().name == "Result")
        {
            if (music == 2)
            {
                audiosource.Stop();
                music--;
            }
        }
    }
}
