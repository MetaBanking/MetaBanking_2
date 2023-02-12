using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Text_Trigger : MonoBehaviour
{
    public GameObject text_show;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //�������� �ȿ� ������ �� �����尡 ������ �� + ����Ű�� ���� ȭ���� ǥ���϶�� �޼���
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            text_show.SetActive(true);
        }

    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            text_show.SetActive(false);
        }

    }
    // Update is called once per frame
    void Update()
    {

    }

}
