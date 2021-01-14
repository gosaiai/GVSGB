using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;


public class CreateRoomMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Text roomName;


    private RoomsCanvases roomCanvases;

    public void FirstInitialize(RoomsCanvases canvases)
    {
        roomCanvases = canvases;
    }

    public void OnClick_CreateRoom()
    {
        if (!PhotonNetwork.IsConnected)
        {
            return;
        }
        RoomOptions options = new RoomOptions();
        options.BroadcastPropsChangeToAll = true;
        options.MaxPlayers = 4;
        PhotonNetwork.JoinOrCreateRoom(roomName.text, options, TypedLobby.Default);
    }

    public override void OnCreatedRoom()
    {
       Debug.Log("Created Room Successfully",this);
        roomCanvases.CurrentRoomCanvas.Show();
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
       Debug.Log("Room Creation Failed :"+message,this);

    }
}
