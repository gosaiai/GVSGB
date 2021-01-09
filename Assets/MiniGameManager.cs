using GVSGB;
using JetBrains.Annotations;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine.SocialPlatforms;
using System.Threading;

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

        [SerializeField]

        public Animator pianoAnimator;

        public GameObject pianoKeyPos;
        [SerializeField]
        colorchangePiano colorchangescript;
        [SerializeField]
        GameObject circle;
        public float Timer = 2f;
        int count;

        // Start is called before the first frame update
        void Start()
        {
            if (pianoAnimator == null)
            {
                pianoAnimator = GetComponent<Animator>();
            }

            //circle.SetActive(false);
            spookBtn.gameObject.SetActive(false);

            incantation.SetActive(false);
            Spookmeter.maxValue = 100f;
            Spookmeter.minValue = 0f;

        }





        void CircleDraw()
        {

            pianoKey();
            InvokeRepeating("pianoKey", 0, 5);
            //
            //Vector2 position = new Vector2(UnityEngine.Random.Range(0.77f, 0.77f), UnityEngine.Random.Range(0.89f, 0.89f));
            //if (circle.transform.localScale >= new Vector3(UnityEngine.Random.Range(0.77f, 0.77f), UnityEngine.Random.Range(0.89f, 0.89f), 0))


            //if ()
            //{
            //    Debug.Log("b");
            //    Renderer rend = circle.GetComponent<Renderer>();
            //    rend.material.color = Color.white;
            //}

        }
        void pianoKey()
        {


            GameObject clone = Instantiate(Resources.Load("circle"), (new Vector3((UnityEngine.Random.Range(0, 7)), 1, 0)), pianoKeyPos.transform.rotation) as GameObject;
           // Destroy(clone, 5f);
            count = GameObject.FindGameObjectsWithTag("Circle").Length;
            //colorchangescript = (colorchangePiano)circle.GetComponent(typeof(colorchangePiano));

            if (count >= 3 && colorchangescript.ifHit != false)
            {
                CancelInvoke("pianoKey");
                Debug.Log("hisdkfsjdkf");
            }



        }

        private void Update()
        {

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
                    // AllMiniGames[0].game.SetActive(true);
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
            //colorchangescript = circle.GetComponent<colorchangePiano>();
            //circle = GameObject.FindGameObjectWithTag("Circle");
            CircleDraw();
            Debug.Log("spook");
            StartCoroutine(spookTime());
        }

        IEnumerator spookTime()
        {
            SoundManager.PlaySound();

            yield return new WaitForSeconds(waitTime);
            stick.gameObject.SetActive(true);
            IncreaseSpooks();
        }
        public void startGame()
        {
            //circle.SetActive(true);
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
