using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookPanelButton : MonoBehaviour
{
    [SerializeField] GameObject bookPanel;
    [SerializeField] Image book1;
    [SerializeField] Image book2;
    [SerializeField] GameObject playerAction;
    private PlayerAction playerActionCs;

    private void Awake()
    {
        playerActionCs = playerAction.GetComponent<PlayerAction>();
    }

    public void PushNext()
    {
        book1.enabled = false;
        book2.enabled = true;

       
    }
    public void PushBack()
    {
        book1.enabled = true;
        book2.enabled = false;
    }
    public void PushQuit()
    {
        bookPanel.SetActive(false);
        playerActionCs.clicked = false;
    }

}
