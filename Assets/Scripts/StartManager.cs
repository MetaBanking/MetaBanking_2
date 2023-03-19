using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    public Button joinButton;

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1395, 988, false);
        joinButton.interactable = true;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void StartMetaB()
    {
        SceneManager.LoadScene("CharacterSelectScene");
    }
}
