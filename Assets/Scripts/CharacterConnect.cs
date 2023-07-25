//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Photon.Pun;
//using GameCreator.Runtime.Characters.Animim;
//using GameCreator.Runtime.Common;
//using GameCreator.Runtime.Characters;

//public class CharacterConnect : MonoBehaviourPun
//{
//    public Character Char;

//    // Start is called before the first frame update
//    void Start()
//    {
//        Char = GetComponent<Character>();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (photonView.IsMine == false)
//        {
//            Char.enabled = false;
//        }else if (photonView.IsMine == true)
//        {
//            Char.enabled = true;
//        }
//    }
//}
