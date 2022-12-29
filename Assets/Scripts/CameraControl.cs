using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CameraControl : MonoBehaviourPun
{
    Transform playerTr;             // ������ Ÿ�� ���ӿ�����Ʈ�� Transform ����
    float dist = 3.0f;              // ī�޶���� ���� �Ÿ�
    float height = 2.0f;            // ī�޶��� ���� ����
    float dampTrace = 20.0f;        // �ε巯�� ������ ���� ����
    private Transform cameraTr;     // ī�޶� �ڽ��� Transform ����

    public float sensitivity = 500f; //���� ����
    float rotationX = 0.0f;          // x�� ȸ����
    float rotationY = 0.0f;          // z�� ȸ����
    float wheelspeed = 10.0f;


    // ���콺 ��ũ��
    public float SmoothTime = 0.2f;

    void Start()
    {
        cameraTr = Camera.main.GetComponent<Transform>();
        playerTr = GetComponent<Transform>();
    }

    void LateUpdate()
    {
        MouseSencer();
    }

    void MouseSencer()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");
        rotationX += x * sensitivity * Time.deltaTime;
        rotationY += y * sensitivity * Time.deltaTime;

        if (rotationY > 30)
        {
            rotationY = 30;
        }
        else if (rotationY < -30)
        {
            rotationY = -30;
        }

        //���� �ƴ϶�� �������� ���ϵ��� ó��
        if (!photonView.IsMine)
            return;

        //// ���� ��ġ, ���� ��ġ, ������(?)
        cameraTr.position = Vector3.Lerp
            (cameraTr.position ,
             playerTr.position - (playerTr.forward * dist) + (Vector3.up * height),
             Time.deltaTime * dampTrace);
        cameraTr.LookAt(playerTr.position + Vector3.up);         // ĳ���� �������� ����

        cameraTr.eulerAngles = new Vector3(-rotationY, rotationX, 0.0f);
    }
}
