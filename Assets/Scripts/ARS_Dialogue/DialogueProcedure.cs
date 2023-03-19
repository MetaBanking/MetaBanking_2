using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueProcedure : MonoBehaviour
{
    public GameObject intro;
    public GameObject account;
    public GameObject book;
    public GameObject helpdesk;
    public GameObject nothanks;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void IntrotoAccount()
    {
        intro.SetActive(false);
        account.SetActive(true);
    }

    public void IntrotoBook()
    {
        intro.SetActive(false);
        book.SetActive(true);
    }

    public void IntrotoHelpDesk()
    {
        intro.SetActive(false);
        helpdesk.SetActive(true);
    }

    public void IntrotoNothanks()
    {
        intro.SetActive(false);
        nothanks.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {
    }

}
