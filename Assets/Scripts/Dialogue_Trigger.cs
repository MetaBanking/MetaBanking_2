using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Dialogue_Trigger : MonoBehaviour
{
    public GameObject dial;
    public GameObject text_show;
    public GameObject text_default;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //일정범위 안에 들어왔을 때 빌보드가 빛나게 함 + 엔터키를 눌러 화면을 표시하라는 메세지
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            text_default.SetActive(false);
            text_show.SetActive(true);
        }

    }

    private void OnTriggerStay(Collider collision)
    {
        if (Input.GetButtonDown("e"))
        {
            dial.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            text_show.SetActive(false);
            dial.SetActive(false);
            text_default.SetActive(true);
        }

    }
    // Update is called once per frame
    void Update()
    {

    }

}
