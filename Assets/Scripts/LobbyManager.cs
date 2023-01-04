using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public Text connectionInfoText;
    public Button joinButton;

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1395, 988, false);
        PhotonNetwork.ConnectUsingSettings();
        joinButton.interactable = false;
        connectionInfoText.text = "���� ������ ���� ��...";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void OnConnectedToMaster()
    {
        joinButton.interactable = true;
        connectionInfoText.text = "������ ���� �Ǿ����ϴ�.";
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        joinButton.interactable = false;
        connectionInfoText.text = "���� ������ ���������ϴ�.";
        PhotonNetwork.ConnectUsingSettings();   // �ٽ� ���� �õ�
    }

    public void Connect()
    {
        joinButton.interactable = false;
        if (PhotonNetwork.IsConnected)
        {
            connectionInfoText.text = "�� ���� ��...";
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            connectionInfoText.text = "���� ������ ���������ϴ�.";
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        connectionInfoText.text = "���ο� �� ������...";
        // �̹� �ִ� �̸��� �������� ���� �ִ� ���ɼ��� �����ϱ� ���� null �� ó��
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 20 });
    }

    public override void OnJoinedRoom()
    {
        connectionInfoText.text = "�� ���� ����";
        PhotonNetwork.LoadLevel("CharacterSelectScene");
    }
}
