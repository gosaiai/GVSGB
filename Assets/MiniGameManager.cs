using GVSGB;
using JetBrains.Annotations;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GVSGB
{
    [SerializeField]
    public class MiniGameManager : MonoBehaviourPun
    {
        //[SerializeField] 
        //public List<MingameBase> AllMiniGames = new List<MingameBase>();
        //public List<GameObject> test = new List<GameObject>();
        //public GamePlayer controller;

        [SerializeField]
        public GameObject incantation;
        //PlayerManager playerUi;

        [SerializeField]
        Canvas canvas;
        [SerializeField]
        public Slider Spookmeter;
        [SerializeField]
        MingameBase minigame;
        [SerializeField]
        bool isOnPiano = false;
        public float waitTime = 5;
        [SerializeField]
        public Joystick stick;
        PhotonView mPV;
        [SerializeField]
        Button spookBtn;
        
        // Start is called before the first frame update
        void Start()
        {


            spookBtn.gameObject.SetActive(false);

            incantation.SetActive(false);
            Spookmeter.maxValue = 100f;
            Spookmeter.minValue = 0f;
        }


        void Update()
        {
            // CameraFollow follow = Incantion.activeBird.gameObject.GetComponent<CameraFollow>();
            spookTime();

            //IncreaseSpooks();
        }





        public void IncreaseSpooks()
        {

            Spookmeter.value += 10;
        }
        public void OnTriggerEnter2D(Collider2D collision)
        {
             mPV = GetComponent<PhotonView>();


            if (mPV.IsMine)
            {
                if (collision.gameObject.tag == "Player")
                {
                    isOnPiano = true;

                    if (isOnPiano == true)
                    {

                        spookBtn.gameObject.SetActive(true);
                    }

                    //SwitchTOMiniGame();
                    //  AllMiniGames[0].game.SetActive(true);
                    //test[0].SetActive(true);
                    //DrawPentagram.Instance.gameObject.SetActive(true);
                    Debug.Log("game");
                    //IncreaseSpooks();
                    //controller.curJoystick.enabled = false;
                    //game = Resources.Load("Incantation") as GameObject;
                    //GameObject gameInstance = Instantiate(game, transform.position, transform.rotation);
                    // We set canvas to be child of instance and not the party prefab from resources.
                    //gameInstance.transform.SetParent(canvas.transform, false);

                }
            }

            else if (!mPV.IsMine)   
            {
                if (collision.gameObject.tag == "Player")
                {
                    isOnPiano = true;

                    if (isOnPiano == true)
                    {

                        spookBtn.gameObject.SetActive(false);
                    }
                }
            }
        }

        public void doSpook()
        {
            stick.gameObject.SetActive(false);


            Debug.Log("spook");
            StartCoroutine(spookTime());
        }

        IEnumerator spookTime()
        {
            SoundManager.PlaySound();
            yield return new WaitForSeconds(waitTime);
            IncreaseSpooks();
            stick.gameObject.SetActive(true);
        }
        public void startGame()
        {
            doSpook();
            //incantation.SetActive(true);
        }

        public void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                isOnPiano = false;
                spookBtn.gameObject.SetActive(false);
            }
        }
    }
}
