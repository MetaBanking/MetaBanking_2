using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Unity.VisualScripting;
using System.Linq;

public class PhotonToVS : MonoBehaviourPunCallbacks
{
    public override void OnConnectedToMaster()
    {
        CustomEvent.Trigger(gameObject, "OnConnectedToMaster");
    }
    public override void OnJoinedRoom()
    {
        CustomEvent.Trigger(gameObject, "OnJoinedRoom");
    }
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        CustomEvent.Trigger(gameObject, "OnJoinRoomFailed");
    }

    [PunRPC]
    void RPCCall(string eventName)
    {
        CustomEvent.Trigger(gameObject, eventName);
    }

    [PunRPC]
    void RPCCall(params object[] args)
    {
        CustomEvent.Trigger(gameObject, (string)args[0], args.Skip(1).ToArray());
    }
}
