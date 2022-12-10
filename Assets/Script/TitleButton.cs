using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour
{
    [SerializeField] GameObject explainPanel;
    public void PushStartButton()
    {
        SceneManager.LoadScene("Main");
    }

    public void PushExplainButton()
    {
        explainPanel.SetActive(true);
    }
    public void PushQuitButton()
    {
        explainPanel.SetActive(false);
    }

}
