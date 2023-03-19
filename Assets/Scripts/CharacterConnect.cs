using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using GameCreator.Runtime.Characters.Animim;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Characters;

public class CharacterConnect : MonoBehaviourPun
{
    public Character Char;

    private PhotonView pv;

    // Start is called before the first frame update
    void Start()
    {
        Char = GetComponent<Character>();
        //Player = GetComponent<Character>().Player;

        pv = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pv.IsMine == false)
        {
            Char.enabled = false;

        }else if (pv.IsMine == true)
        {
            Char.enabled = true;
        }
    }
}
