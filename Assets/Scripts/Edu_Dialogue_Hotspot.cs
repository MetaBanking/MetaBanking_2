using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Edu_Dialogue_Hotspot : MonoBehaviour
{
    public GameObject text;
    public GameObject dialogue_edu;


    // Start is called before the first frame update
    void Start()
    {
        Input.multiTouchEnabled = false;

    }

    //일정범위 안에 들어왔을 때 텍스트가 보이게 함 + E 키를 눌러 화면을 표시하라는 메세지
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            text.SetActive(true);
        }

    }

    private void OnTriggerStay(Collider collision)
    {
        if (Input.GetButtonDown("e"))
        {
            text.SetActive(false);
            dialogue_edu.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            text.SetActive(false);
            dialogue_edu.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    { }
}
