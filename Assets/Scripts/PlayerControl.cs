using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

// ����Ƽ���� �����尡 ����.
public class PlayerControl : MonoBehaviourPun
{
    // �⺻�� private => private Ű����� ���� ����
    float h = 0.0f;                 // ��, �� ���� ���� ����
    float v = 0.0f;                 // ��, �� ���� ���� ����
    float r = 0.0f;                 // ȸ������ ���� ����
    float moveSpeed = 5.0f;         // �̵� �ӵ� (�Ÿ�)
    float rotationSpeed = 500.0f;   // ȸ�� �ӵ��� ���� ����
    Transform playerTr;             // ���ΰ��� Transform �� ������ ����
    static int bottle = 0;                 // ȹ���� Ű�� ����

    // ��Ʈ��ũ�� �ø��� ���� component �� ���콺�� ����� ���� �� ���������� ��.

    // Jump
    bool isJump = false;            //������ �ƴ� ��� false, ���� ���̸�true
    float jumpPower = 5.0f;
    Rigidbody rigidbody;

    // Sound
    AudioSource audioSource;
    // public AudioClip audioClip;

    // Effect
    // public GameObject effectObject;

    // Animation
    Animator animator;

    // Start is called before the first frame update - �ʱ�ȭ���� ����
    void Start()
    {
        // ���� ����Ǿ� �ִ� Object �� Transform (9���� �����͸� ����) �� �����Ͷ�!
        playerTr = GetComponent<Transform>();   // GetComponent �տ��� this.gameObject. �� �����Ǿ� ����.
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame - �ݺ������� �����ϴ� ��
    void Update()
    {
        //���� �ƴ϶�� �������� ���ϵ��� ó��
        if (!photonView.IsMine)
            return;

        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        r = Input.GetAxis("Mouse X");
        
        // �޸��� ȿ��
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 10.0f;
        }
        else
        {
            moveSpeed = 3.0f;
        }
        if (v < 0)
            v = 0;
        // ����
        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);

        // Space
        //  World ��ǥ�� Ư�� ��ġ�� ã�� ����� ������ Local �� ��ȣ��??????? (���鼭 ��...)
        playerTr.Translate(moveDir.normalized * moveSpeed * Time.deltaTime, Space.Self);

        playerTr.Rotate(new Vector3(0, r, 0) * rotationSpeed * Time.deltaTime);

        // Jump: �ٴڿ� �پ����� ���� ������ �����ϵ���!
        if (Input.GetButtonDown("Jump") && isJump == false)
        {
            rigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            isJump = true;
        }

        // Animation
        if (v == 0.0f && h == 0.0f)
        {
            // Stop
            animator.SetBool("Walk", false);
        }
        else
        {
            // Walk
            animator.SetBool("Walk", true);
        }
    }

    // collision: ���� �΋H�� �༮�� ������ ��� �ִ� ����
    private void OnCollisionEnter(Collision collision)
    {
        //���� �ƴ϶�� �������� ���ϵ��� ó��
        if (!photonView.IsMine)
            return;

        Debug.Log("���� ���� " + isJump);
        Debug.Log("�±� " + collision.gameObject.tag);
        // Jump
        if (collision.gameObject.tag == "Floor") {
            isJump = false;
        }
    }
}
