using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

//�ڵ� ���� 1: https://www.youtube.com/watch?v=oWlUZTLO3Vw
//�ڵ� ���� 2: https://ojui.tistory.com/40

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public Text connectionInfoText;
    public Button joinButton;

    //���� �Է�
    private readonly string version = "1.0f";
    // ����� ���̵� �Է�
    public string userId;

    private void Awake()
    {
        //���� ���� �����鿡�� �ڵ����� ���� �ε�
        PhotonNetwork.AutomaticallySyncScene = true;
        //���� ������ �������� ���� ���
        PhotonNetwork.GameVersion = version;
        //���� ���̵� �Ҵ�
        PhotonNetwork.NickName = userId;
        //���� ������ ��� Ƚ�� ����. �ʴ� 30ȸ
        Debug.Log(PhotonNetwork.SendRate);
        //���� ����
        PhotonNetwork.ConnectUsingSettings();
    }

    //���� ������ ���� �� ȣ��Ǵ� �ݹ� �Լ�
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master!");
        Debug.Log($"PhotonNetwork.InLobby = {PhotonNetwork.InLobby}");

        joinButton.interactable = true;
        connectionInfoText.text = "������ ���� �Ǿ����ϴ�.";

        PhotonNetwork.JoinLobby();  //�κ� ����
    }

    //�κ� ���� �� ȣ��Ǵ� �ݹ� �Լ�
    public override void OnJoinedLobby()
    {
        Debug.Log($"PhotonNetwork.InLobby = {PhotonNetwork.InLobby}");

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

    //������ �� ������ �������� ��� ȣ��Ǵ� �ݹ� �Լ�
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log($"JoinRandom Filed {returnCode}:{message}");

        //�� �Ӽ� ����
        RoomOptions ro = new RoomOptions();
        ro.MaxPlayers = 20;      //�ִ� ������ �� : 20��
        ro.IsOpen = true;       //���� ���� ����
        ro.IsVisible = true;    //�κ񿡼� �� ��Ͽ� �����ų�� ����

        //�� ����
        PhotonNetwork.CreateRoom("My Room", ro);
    }

    //�� ������ �Ϸ�� �� ȣ��Ǵ� �ݹ� �Լ�
    public override void OnCreatedRoom()
    {
        Debug.Log("Created Room");
        Debug.Log($"Room Name = {PhotonNetwork.CurrentRoom.Name}");
    }

    //�뿡 ������ �� ȣ��Ǵ� �ݹ� �Լ�
    public override void OnJoinedRoom()
    {
        connectionInfoText.text = "�� ���� ����";

        Debug.Log($"PhotonNetwork.InRoom = {PhotonNetwork.InRoom}");
        //���� �뿡 ������ ����� ��
        Debug.Log($"Player Count = {PhotonNetwork.CurrentRoom.PlayerCount}");

        //�뿡 ������ ����� ���� Ȯ��
        foreach (var player in PhotonNetwork.CurrentRoom.Players)
        {
            //$ => String.Format() 
            Debug.Log($"{player.Value.NickName},{player.Value.ActorNumber}");

        }

        PhotonNetwork.LoadLevel("CharacterSelectScene");

    }


    // Start is called before the first frame update
    void Start()
    {
        //id �ڵ� ����
        userId = PlayerPrefs.GetString("USER_ID",$"USER_{Random.Range(0,100):00}");

        Screen.SetResolution(1395, 988, false);
        joinButton.interactable = false;
        connectionInfoText.text = "���� ������ ���� ��...";
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*public override void OnConnectedToMaster()
    {
        joinButton.interactable = true;
        connectionInfoText.text = "������ ���� �Ǿ����ϴ�.";
    }*/

    public override void OnDisconnected(DisconnectCause cause)
    {
        joinButton.interactable = false;
        connectionInfoText.text = "���� ������ ���������ϴ�.";
        PhotonNetwork.ConnectUsingSettings();   // �ٽ� ���� �õ�
    }

    /*public void Connect()
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
    }*/

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        connectionInfoText.text = "���ο� �� ������...";
        // �̹� �ִ� �̸��� �������� ���� �ִ� ���ɼ��� �����ϱ� ���� null �� ó��
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 20 });
    }

    /*public override void OnJoinedRoom()
    {
        connectionInfoText.text = "�� ���� ����";
        PhotonNetwork.LoadLevel("CharacterSelectScene");
    }*/
}
