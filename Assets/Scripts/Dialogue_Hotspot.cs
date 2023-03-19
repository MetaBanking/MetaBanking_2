using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_Hotspot : MonoBehaviour
{
    public GameObject text_show;
    public GameObject dial;


    // Start is called before the first frame update
    void Start()
    {

    }

    //�������� �ȿ� ������ �� �ؽ�Ʈ�� ���̰� �� + E Ű�� ���� ȭ���� ǥ���϶�� �޼���
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            text_show.SetActive(true);
        }

    }

    private void OnTriggerStay(Collider collision)
    {
        if (Input.GetButtonDown("e"))
        {
            text_show.SetActive(false);
            dial.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            dial.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    { }    
}
