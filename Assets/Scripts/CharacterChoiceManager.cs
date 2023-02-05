using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class CharacterChoiceManager : MonoBehaviourPunCallbacks
{
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
        GameManager.character = "";
    }

    public void setCharacterAsFemail2()
    {
        PhotonNetwork.LoadLevel("MainScene");
        GameManager.character = "";
    }

    public void setCharacterAsFemail3()
    {
        PhotonNetwork.LoadLevel("MainScene");
        GameManager.character = "";
    }

    public void setCharacterAsFemail4()
    {
        PhotonNetwork.LoadLevel("MainScene");
        GameManager.character = "";
    }
}
