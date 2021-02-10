using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class LobbyNetworkManager : MonoBehaviourPunCallbacks
{
    #region Private Serializable Fields
    [SerializeField]
    private GameObject inputField;

    [SerializeField]
    private RoomItemUI roomUIPrefab;

    [SerializeField]
    private Transform roomListParent;

    [SerializeField]
    private RoomItemUI playerUIPrefab;

    [SerializeField]
    private Transform playerListParent;

    [SerializeField]
    private TextMeshProUGUI statusField;

    [SerializeField]
    private Button leaveButton;

    [SerializeField]
    private Button startButton;

    [Tooltip("The maximum number of players per room. When a room is full, it can't be joined by new players, and so new room will be created")]
    [SerializeField]
    private byte maxPlayersPerRoom = 5;
    #endregion

    #region Private Fields
    string gameVersion = "1";
    bool isConnecting;
    private List<RoomItemUI> _roomList = new List<RoomItemUI>();
    private List<RoomItemUI> _playerList = new List<RoomItemUI>();

    #endregion

    [SerializeField]
    public GameObject roomListingMenu;

    [SerializeField]
    public GameObject playerListingMenu;

    

    #region MonoBehaviour Callbacks
    void Awake()
    {
        // #Critical
        // this makes sure we can use PhotonNetwork.LoadLevel() on the master client and all clients in the same room sync their level automatically
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    private void Start()
    {
        Initialize();
        Connect();
    }


    #endregion
    #region PhotonCallbacks
    public override void OnConnectedToMaster()
    {
        if (isConnecting)
        {
            Debug.LogError("Connected To Master Server!!");
            PhotonNetwork.JoinLobby();
            isConnecting = false;
        }
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        UpdateRoomList(roomList);
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogError("Disconnected from photon");
        isConnecting = false;
    }

    public override void OnJoinedLobby()
    {
        Debug.LogError("JoinedLobby");
    }

    public override void OnJoinedRoom()
    {
        statusField.text = "Joined" + PhotonNetwork.CurrentRoom.Name;
        leaveButton.interactable = true;
        Debug.LogError("Joined Room : " + PhotonNetwork.CurrentRoom.Name);
        UpdatePlayerList();

        if (PhotonNetwork.IsMasterClient)
        {
            startButton.interactable = true;
        }
    }

    public override void OnLeftRoom()
    {
        statusField.text = "LOBBY";
        leaveButton.interactable = false;
        startButton.interactable = false;
        Debug.LogError("Left Room");
        UpdatePlayerList();

    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        UpdatePlayerList();
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        UpdatePlayerList();

    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("PUN Basics Tutorial/Launcher:OnJoinRandomFailed() was called by PUN. No random room available, so we create one.\nCalling: PhotonNetwork.CreateRoom");

        // #Critical: we failed to join a random room, maybe none exists or they are all full. No worries, we create a new room.
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = maxPlayersPerRoom });
    }

    #endregion

    #region Custom Functions
    private void Initialize()
    {
        leaveButton.interactable = false;
    }

    private void Connect()
    {
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.NickName = "Player" + Random.Range(0, 1000);
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.AutomaticallySyncScene = true;
        }
        else
        {
            // #Critical, we must first and foremost connect to Photon Online Server.
            isConnecting = PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.GameVersion = gameVersion;
        }
    }

    private void UpdateRoomList(List<RoomInfo> roomList)
    {
        //Clear the current room list
        
        for(int i = 0; i < _roomList.Count; i++)
        {
            Destroy(_roomList[i].gameObject);
        }

        _roomList.Clear();

        //Generate a new list with updated info
        for(int i =0; i< roomList.Count; i++)
        {
            //skip empty rooms
            if (roomList[i].PlayerCount == 0) { continue; }

            RoomItemUI newRoomItem = Instantiate(roomUIPrefab);
            newRoomItem.LobbyNetworkParent = this;
            newRoomItem.SetName(roomList[i].Name);
            newRoomItem.transform.SetParent(roomListParent);

            _roomList.Add(newRoomItem);
        }
    }

    private void UpdatePlayerList()
    {
        //clear the current player list
        for (int i = 0; i < _playerList.Count; i++)
        {
            Destroy(_playerList[i].gameObject);
        }

        _playerList.Clear();

        if(PhotonNetwork.CurrentRoom == null) { return; }

        //update new player list
        foreach(KeyValuePair<int,Player> player in PhotonNetwork.CurrentRoom.Players)
        {
            RoomItemUI newPlayerItem = Instantiate(playerUIPrefab);
            newPlayerItem.transform.SetParent(playerListParent);
            string text = inputField.GetComponent<TMP_InputField>().text;
            //newPlayerItem.SetName(text);
            newPlayerItem.SetName(player.Value.NickName);

            _playerList.Add(newPlayerItem);

        }

    }

    public void JoinRoom(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
    }

    //Join Random Room
    public void JoinRoom2()
    {
        PhotonNetwork.JoinRandomRoom();
        Debug.LogError("Joined Random Room");
    }

    public void CreateRoom()
    {
        string text = inputField.GetComponent<TMP_InputField>().text;
        if (string.IsNullOrEmpty(text) == false)
        {
            PhotonNetwork.CreateRoom(text, new RoomOptions() { MaxPlayers = 4 }, null);
        }
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public void OnStartGamePressed()
    {
        PhotonNetwork.LoadLevel("NetWorkTestScene");
    }
    #endregion
}
