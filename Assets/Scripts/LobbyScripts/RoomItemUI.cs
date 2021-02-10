using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RoomItemUI : MonoBehaviour
{

    public LobbyNetworkManager LobbyNetworkParent;
    [SerializeField]
    private TextMeshProUGUI _roomName;
    
    

    public void SetName(string roomName)
    {
        _roomName.text = roomName;
    }

    public void OnJoinPressed()
    {
        LobbyNetworkParent.JoinRoom(_roomName.text);
        LobbyNetworkParent.roomListingMenu.SetActive(false);
        LobbyNetworkParent.playerListingMenu.SetActive(true);
    }

    
}
