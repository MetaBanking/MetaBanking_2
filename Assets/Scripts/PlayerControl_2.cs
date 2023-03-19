using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

// 유니티에는 쓰레드가 없음.
public class PlayerControl_2 : MonoBehaviourPun
{
    // 기본이 private => private 키워드는 생략 가능
    float h = 0.0f;                 // 좌, 우 값을 담을 변수
    float v = 0.0f;                 // 상, 하 값을 담을 변수
    float r = 0.0f;                 // 회전값을 담을 변수
    float moveSpeed = 5.0f;         // 이동 속도 (거리)
    float rotationSpeed = 500.0f;   // 회전 속도를 담을 변수
    Transform playerTr;             // 주인공의 Transform 을 저장할 변수
    static int bottle = 0;                 // 획득한 키의 갯수

    // Jump
    bool isJump = false;            //점프가 아닌 경우 false, 점프 중이면true
    float jumpPower = 5.0f;
    Rigidbody rigidbody;

    // Sound
    AudioSource audioSource;
    public AudioClip audioClip;

    // Effect
    public GameObject effectObject;

    // Animation
    Animator animator;

    // Start is called before the first frame update - 초기화같은 느낌
    void Start()
    {
        // 나랑 연결되어 있는 Object 의 Transform (9가지 데이터를 가짐) 을 가져와라!
        playerTr = GetComponent<Transform>();   // GetComponent 앞에는 this.gameObject. 가 생략되어 있음.
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame - 반복적으로 동작하는 거
    void Update()
    {
        //로컬 아니라면 진입하지 못하도록 처리
        if (!photonView.IsMine)
            return;

        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        r = Input.GetAxis("Mouse X");
        // Debug.Log("H: " + h.ToString() + ", V: " + v.ToString());

        // 달리기 효과
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 10.0f;
        }
        else
        {
            moveSpeed = 3.0f;
        }

        // 방향
        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);

        // Vector3: 왼손 좌표계. x, y, z 임!
        // playerTr.Translate(new Vector3(h, 0, v) * moveSpeed * Time.deltaTime);

        // Space
        //  World 좌표는 특정 위치도 찾기 힘들기 때문에 Local 을 선호함??????? (졸면서 씀...)
        playerTr.Translate(moveDir.normalized * moveSpeed * Time.deltaTime, Space.Self);

        playerTr.Rotate(new Vector3(0, r, 0) * rotationSpeed * Time.deltaTime);

        // Jump: 바닥에 붙어있을 때만 점프가 가능하도록!
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

    // collision: 나랑 부딫힌 녀석의 정보를 담고 있는 변수
    private void OnCollisionEnter(Collision collision)
    {
        //로컬 아니라면 진입하지 못하도록 처리
        if (!photonView.IsMine)
            return;

        if (collision.gameObject.tag == "BOTTLE")
        {
            if (bottle < 3)
            {
                bottle += 1;
                Debug.Log("획득한 보틀 수 : " + bottle.ToString());

                // audioClip 의 오디오 파일을 한 번만 재생해라!
                audioSource.PlayOneShot(audioClip);

                // Effect
                Vector3 effectPosition = collision.gameObject.GetComponent<Transform>().position;   // 병의 위치값
                GameObject effect = Instantiate(effectObject, effectPosition, Quaternion.identity); // 
                Destroy(effect, 2.0f);
                Destroy(collision.gameObject);
            }
        }

        // Jump
        if (collision.gameObject.name == "Floor")
        {
            isJump = false;
        }
    }
}
