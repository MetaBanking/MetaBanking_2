using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Info_Dialogue_Hotspot : MonoBehaviour
{
    public GameObject text_i;
    public GameObject dialogue_info;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            text_i.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(Input.GetButtonDown("e"))
        {
            text_i.SetActive(false); 
            dialogue_info.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        text_i.SetActive(false);
        dialogue_info.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
