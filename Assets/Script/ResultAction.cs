using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultAction : MonoBehaviour
{
    private GameObject data;
    private Data dataCs;
    void Start()
    {
        data = GameObject.Find("Data");
        dataCs = data.GetComponent<Data>();
    }

    public void PushRestartButton()
    {
        Destroy(data);
        SceneManager.LoadScene("Main");
    }
}
