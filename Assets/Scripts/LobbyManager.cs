using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

//코드 참고 1: https://www.youtube.com/watch?v=oWlUZTLO3Vw
//코드 참고 2: https://ojui.tistory.com/40

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public Text connectionInfoText;
    public Button joinButton;

    //버전 입력
    private readonly string version = "1.0f";
    // 사용자 아이디 입력
    public string userId;

    private void Awake()
    {
        //같은 룸의 유저들에게 자동으로 씬을 로딩
        PhotonNetwork.AutomaticallySyncScene = true;
        //같은 버전의 유저끼리 접속 허용
        PhotonNetwork.GameVersion = version;
        //유저 아이디 할당
        PhotonNetwork.NickName = userId;
        //포톤 서버와 통신 횟수 설정. 초당 30회
        Debug.Log(PhotonNetwork.SendRate);
        //서버 접속
        PhotonNetwork.ConnectUsingSettings();
    }

    //포톤 서버에 접속 후 호출되는 콜백 함수
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master!");
        Debug.Log($"PhotonNetwork.InLobby = {PhotonNetwork.InLobby}");

        joinButton.interactable = true;
        connectionInfoText.text = "서버에 연결 되었습니다.";

        PhotonNetwork.JoinLobby();  //로비 입장
    }

    //로비에 접속 후 호출되는 콜백 함수
    public override void OnJoinedLobby()
    {
        Debug.Log($"PhotonNetwork.InLobby = {PhotonNetwork.InLobby}");

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

    //랜덤한 룸 입장이 실패했을 경우 호출되는 콜백 함수
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log($"JoinRandom Filed {returnCode}:{message}");

        //룸 속성 정의
        RoomOptions ro = new RoomOptions();
        ro.MaxPlayers = 20;      //최대 접속자 수 : 20명
        ro.IsOpen = true;       //룸의 오픈 여부
        ro.IsVisible = true;    //로비에서 룸 목록에 노출시킬지 여부

        //룸 생성
        PhotonNetwork.CreateRoom("My Room", ro);
    }

    //룸 생성이 완료된 후 호출되는 콜백 함수
    public override void OnCreatedRoom()
    {
        Debug.Log("Created Room");
        Debug.Log($"Room Name = {PhotonNetwork.CurrentRoom.Name}");
    }

    //룸에 입장한 후 호출되는 콜백 함수
    public override void OnJoinedRoom()
    {
        connectionInfoText.text = "방 참가 성공";

        Debug.Log($"PhotonNetwork.InRoom = {PhotonNetwork.InRoom}");
        //현재 룸에 접속한 사용자 수
        Debug.Log($"Player Count = {PhotonNetwork.CurrentRoom.PlayerCount}");

        //룸에 접속한 사용자 정보 확인
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
        //id 자동 생성
        userId = PlayerPrefs.GetString("USER_ID",$"USER_{Random.Range(0,100):00}");

        Screen.SetResolution(1395, 988, false);
        joinButton.interactable = false;
        connectionInfoText.text = "게임 서버에 접속 중...";
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*public override void OnConnectedToMaster()
    {
        joinButton.interactable = true;
        connectionInfoText.text = "서버에 연결 되었습니다.";
    }*/

    public override void OnDisconnected(DisconnectCause cause)
    {
        joinButton.interactable = false;
        connectionInfoText.text = "서버 연결이 끊어졌습니다.";
        PhotonNetwork.ConnectUsingSettings();   // 다시 접속 시도
    }

    /*public void Connect()
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
    }*/

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        connectionInfoText.text = "새로운 방 생성중...";
        // 이미 있는 이름을 설정했을 수도 있는 가능성을 방지하기 위해 null 로 처리
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 20 });
    }

    /*public override void OnJoinedRoom()
    {
        connectionInfoText.text = "방 참가 성공";
        PhotonNetwork.LoadLevel("CharacterSelectScene");
    }*/
}
