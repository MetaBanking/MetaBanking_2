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
        connectionInfoText.text = "게임 서버에 접속 중...";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void OnConnectedToMaster()
    {
        joinButton.interactable = true;
        connectionInfoText.text = "서버에 연결 되었습니다.";
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        joinButton.interactable = false;
        connectionInfoText.text = "서버 연결이 끊어졌습니다.";
        PhotonNetwork.ConnectUsingSettings();   // 다시 접속 시도
    }

    public void Connect()
    {
        joinButton.interactable = false;
        if (PhotonNetwork.IsConnected)
        {
            connectionInfoText.text = "룸 접속 중...";
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            connectionInfoText.text = "서버 연결이 끊어졌습니다.";
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        connectionInfoText.text = "새로운 방 생성중...";
        // 이미 있는 이름을 설정했을 수도 있는 가능성을 방지하기 위해 null 로 처리
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 20 });
    }

    public override void OnJoinedRoom()
    {
        connectionInfoText.text = "방 참가 성공";
        PhotonNetwork.LoadLevel("CharacterSelectScene");
    }
}
