using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair_Trigger : MonoBehaviour
{
    public GameObject chair;
    public GameObject text_show;

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
}
