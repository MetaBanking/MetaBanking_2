using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class CharacterChoiceManager : MonoBehaviourPunCallbacks
{
    public Button female1, female2, female3, female4;

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setCharacterAsFemail1()
    {
        PhotonNetwork.LoadLevel("MainScene");
        GameManager.character = 1;
    }

    public void setCharacterAsFemail2()
    {
        PhotonNetwork.LoadLevel("MainScene");
        GameManager.character = 2;
    }

    public void setCharacterAsFemail3()
    {
        PhotonNetwork.LoadLevel("MainScene");
        GameManager.character = 3;
    }

    public void setCharacterAsFemail4()
    {
        PhotonNetwork.LoadLevel("MainScene");
        GameManager.character = 4;
    }
}
