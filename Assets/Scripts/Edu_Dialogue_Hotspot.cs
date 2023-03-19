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

    //�������� �ȿ� ������ �� �ؽ�Ʈ�� ���̰� �� + E Ű�� ���� ȭ���� ǥ���϶�� �޼���
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
