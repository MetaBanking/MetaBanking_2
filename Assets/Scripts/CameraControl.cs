using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CameraControl : MonoBehaviourPun
{
    Transform playerTr;             // 추적할 타겟 게임오브젝트의 Transform 변수
    float dist = 5.0f;             // 카메라와의 일정 거리
    float height = 2.0f;            // 카메라의 높이 설정
    float dampTrace = 20.0f;        // 부드러운 추적을 위한 변수
    private Transform cameraTr;     // 카메라 자신의 Transform 변수

    void Start()
    {
        cameraTr = Camera.main.GetComponent<Transform>();
        playerTr = GetComponent<Transform>();
    }

    void LateUpdate()
    {
        //로컬 아니라면 진입하지 못하도록 처리
        if (!photonView.IsMine)
            return;

        // 시작 위치, 도착 위치, 보정값(?)
        cameraTr.position = Vector3.Lerp
            (cameraTr.position, 
             playerTr.position - (playerTr.forward * dist) + (Vector3.up * height),
             Time.deltaTime * dampTrace);
        cameraTr.LookAt(playerTr.position + Vector3.up);         // 캐릭터 방향으로 보기
    }
}
