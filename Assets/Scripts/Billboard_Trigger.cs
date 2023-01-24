using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Billboard_Trigger : MonoBehaviour
{
    public GameObject news;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //�������� �ȿ� ������ �� �����尡 ������ �� + ����Ű�� ���� ȭ���� ǥ���϶�� �޼���
    private void OnTriggerEnter(Collider collision)
    {
        if ( collision.gameObject.tag == "Player")
        {
            UnityEngine.Debug.Log("enter");
            news.SetActive(true);
        }

    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.name.Equals("Tester"))
        {
            UnityEngine.Debug.Log("out");
            news.SetActive(false);
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
