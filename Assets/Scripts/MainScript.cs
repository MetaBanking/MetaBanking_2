using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
    private GameObject NPCDialog, InfoDialog;
    private Text NPCText, InfoText;
    private Image InfoImg;

    void Start()
    {
        // NPC 대화
        NPCDialog = GameObject.Find("NPCDialog");
        NPCText = GameObject.Find("NPCText").GetComponent<Text>();
        NPCDialog.SetActive(false);

        // 경제 뉴스
        InfoDialog = GameObject.Find("InfoDialog");
        InfoText = GameObject.Find("InfoText").GetComponent<Text>();
        InfoImg = GameObject.Find("InfoImg").GetComponent<Image>();
        InfoDialog.SetActive(false);
    }

    public void NPCChatEnter(string text)
    {
        NPCText.text = text;
        NPCDialog.SetActive(true);
    }

    public void NPCChatExit()
    {
        NPCText.text = "";
        NPCDialog.SetActive(false);
    }

    public void InfoEnter(string text)
    {
        InfoText.text = text;
        InfoImg.enabled = true;
        InfoDialog.SetActive(true);
    }

    public void InfoExit()
    {
        InfoText.text = "";
        InfoImg.enabled = false;
        InfoDialog.SetActive(false);
    }
}