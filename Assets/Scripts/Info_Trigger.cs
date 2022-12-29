using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Info_Trigger : MonoBehaviour
{
    public string ChatText = "";
    private GameObject Main;
    void Start()
    {
        Main = GameObject.Find("Main");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            Main.GetComponent<MainScript>().InfoEnter(ChatText);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            Main.GetComponent<MainScript>().InfoExit();
        }
    }
}
