using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edu_procedure : MonoBehaviour
{
    public GameObject intro;
    public GameObject menu;
    public GameObject video;
    public GameObject dictionary;
    public GameObject nothanks;
    // Start is called before the first frame update
    public void IntrotoAccount()
    {
        intro.SetActive(false);
        menu.SetActive(true);
    }

    public void IntrotoBook()
    {
        menu.SetActive(false);
        video.SetActive(true);
    }

    public void IntrotoHelpDesk()
    {
        menu.SetActive(false);
        dictionary.SetActive(true);
    }

    public void IntrotoNothanks()
    {
        menu.SetActive(false);
        nothanks.SetActive(true);
    }

}
