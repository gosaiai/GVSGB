using GVSGB;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GVSGB
{
    [SerializeField]
    public class MiniGameManager : Singleton<MiniGameManager>
    {
        //[SerializeField] 
        //public List<MingameBase> AllMiniGames = new List<MingameBase>();
        //public List<GameObject> test = new List<GameObject>();
        //public GamePlayer controller;

        [SerializeField]
        public GameObject incantation;
        //PlayerManager playerUi;
        [SerializeField]
        GameObject mainCamera;
        [SerializeField]
        GameObject miniGameCamera;
        [SerializeField]
        Canvas canvas;
        [SerializeField]
        public Slider Spookmeter;
        [SerializeField]
        MingameBase minigame;
        [SerializeField]
        bool isOnPiano = false;
       
        
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
        public void SwitchTOMiniGame()
        {
            mainCamera.SetActive(false);

            miniGameCamera.SetActive(true);

            //joystick.activeJoyStick.gameObject.SetActive(false);

        }
        public void SwitchToMainGame()
        {
            mainCamera.SetActive(true);
            miniGameCamera.SetActive(false);
        }
        // Update is called once per frame
        void Update()
        {
           // CameraFollow follow = Incantion.activeBird.gameObject.GetComponent<CameraFollow>();

            
            //IncreaseSpooks();
        }

       

       

        public void IncreaseSpooks()
        {

            Spookmeter.value += 10;
        }
        public void OnTriggerEnter2D(Collider2D collision)
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
                IncreaseSpooks();
                //controller.curJoystick.enabled = false;
                //game = Resources.Load("Incantation") as GameObject;
                //GameObject gameInstance = Instantiate(game, transform.position, transform.rotation);
                // We set canvas to be child of instance and not the party prefab from resources.
                //gameInstance.transform.SetParent(canvas.transform, false);

            }
        }

        public void startGame()
        {
            incantation.SetActive(true);
        }

        public void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player" && minigame.MyState == MiniGameState.INPROGRESS)
            {
                incantation.SetActive(false);
                Debug.Log("in cant");
                Incantation.Instance.Restart();
            }

            else if (collision.gameObject.tag == "Player")
            {
                isOnPiano = false;
                spookBtn.gameObject.SetActive(false);
            }
        }
    }
}
