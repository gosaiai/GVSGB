using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;


namespace GVSGB
{
    public class GameManager : MonoBehaviourPunCallbacks
    {
        #region public Fields
        public static GameManager Instance;
        [Tooltip("The prefab to use for representing the player")]
        public GameObject playerPrefab;
        //public GameObject busterPrefab;
        
        #endregion
        GamePlayer[] gamePlayer;
        #region Photon Callbacks

        /// <summary>
        /// Called when the local player left the room. We need to load the launcher scene.
        /// </summary>
        public override void OnLeftRoom()
        {
            SceneManager.LoadScene(0);
        }


        #endregion
        #region Private Methods


        void LoadArena()
        {
            if (!PhotonNetwork.IsMasterClient)
            {
                Debug.LogError("PhotonNetwork : Trying to Load a level but we are not the master Client");
            }
            if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
            {
                Debug.LogFormat("PhotonNetwork : Loading Level : {0}", PhotonNetwork.CurrentRoom.PlayerCount);
                //  PhotonNetwork.LoadLevel("For" + PhotonNetwork.CurrentRoom.PlayerCount + " Players");



                // #Critical
                // Load the Room Level.
                PhotonNetwork.LoadLevel("NetWorkTestScene");
            }

        }


        #endregion
        #region MonoBehaviour CallBacks
        
        void Start()
        {
            
            Instance = this;
            if (playerPrefab == null)
            {
                Debug.LogError("<Color=Red><a>Missing</a></Color> playerPrefab Reference. Please set it up in GameObject 'Game Manager'", this);
            }
            else
            {
                if (PlayerManager.LocalPlayerInstance == null)
                {
                    Debug.LogFormat("We are Instantiating LocalPlayer from {0}", SceneManagerHelper.ActiveSceneName);
                    // we're in a room. spawn a character for the local player. it gets synced by using PhotonNetwork.Instantiate
                                       
                    PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector3(0f, 5f, -14f), Quaternion.identity, 0);
                    //PhotonNetwork.Instantiate(this.busterPrefab.name, new Vector3(0f, 5f, -14f), Quaternion.identity, 0);
                }
                else
                {
                    Debug.LogFormat("Ignoring scene load for {0}", SceneManagerHelper.ActiveSceneName);
                }
            }
        }
        #endregion
        #region Public Methods


        public void LeaveRoom()
        {
            //Debug.Log("button hit");
            PhotonNetwork.LeaveRoom();
        }


        #endregion
        #region Photon Callbacks

   
        public override void OnPlayerEnteredRoom(Player other)
        {
            Debug.LogFormat("OnPlayerEnteredRoom() {0}", other.NickName); // not seen if you're the player connecting
            
            //get id from other and get id from game player.photon component// and match those id then switch
            if (PhotonNetwork.IsMasterClient)
            {
                Debug.LogFormat("OnPlayerEnteredRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient); // called before OnPlayerLeftRoom

                
                LoadArena();
            }
        }


        public override void OnPlayerLeftRoom(Player other)
        {
            Debug.LogFormat("OnPlayerLeftRoom() {0}", other.NickName); // seen when other disconnects


            if (PhotonNetwork.IsMasterClient)
            {
                Debug.LogFormat("OnPlayerLeftRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient); // called before OnPlayerLeftRoom


                LoadArena();
            }
        }


        #endregion
    }
}