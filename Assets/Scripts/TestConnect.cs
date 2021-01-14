using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class TestConnect : MonoBehaviourPunCallbacks
{
   
    void Start()
    {
        Debug.Log("Connecting to server",this);
        PhotonNetwork.SendRate = 20;//20
        PhotonNetwork.SerializationRate = 5;//10
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.NickName = MasterManager.GameSettings.NickName;
        PhotonNetwork.GameVersion = MasterManager.GameSettings.GameVersion;
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Photon", this);

        Debug.Log("My NickName is " + PhotonNetwork.LocalPlayer.NickName, this);
        if (!PhotonNetwork.InLobby)
            PhotonNetwork.JoinLobby();
            
    }   

    public override void OnDisconnected(DisconnectCause cause)
    {
        print("Disconnected because " + cause.ToString());
    }

    public override void OnJoinedLobby()
    {
        print("Joined Lobby");
    }
}
