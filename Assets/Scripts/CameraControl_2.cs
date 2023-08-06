using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CameraControl_2 : MonoBehaviourPun
{
    Transform playerTr;             // ������ Ÿ�� ���ӿ�����Ʈ�� Transform ����
    float dist = 5.0f;             // ī�޶���� ���� �Ÿ�
    float height = 2.0f;            // ī�޶��� ���� ����
    float dampTrace = 20.0f;        // �ε巯�� ������ ���� ����
    private Transform cameraTr;     // ī�޶� �ڽ��� Transform ����

    void Start()
    {
        cameraTr = Camera.main.GetComponent<Transform>();
        playerTr = GetComponent<Transform>();
    }

    void LateUpdate()
    {
        //���� �ƴ϶�� �������� ���ϵ��� ó��
        if (!photonView.IsMine)
            return;

        // ���� ��ġ, ���� ��ġ, ������(?)
        cameraTr.position = Vector3.Lerp
            (cameraTr.position, 
             playerTr.position - (playerTr.forward * dist) + (Vector3.up * height),
             Time.deltaTime * dampTrace);
        cameraTr.LookAt(playerTr.position + Vector3.up);         // ĳ���� �������� ����
    }
}
