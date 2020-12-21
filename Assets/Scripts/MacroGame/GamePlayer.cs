using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;

namespace GVSGB
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
    public class GamePlayer : MonoBehaviourPun
    {
        #region  private fields
        [SerializeField]
        float speed;
        Rigidbody2D rb2d;
        Collider2D col2d;
        private PlayerState playerState = PlayerState.DEAD;
        private CharecterClass charecterClass;// = CharecterClass.GHOST;
        #endregion
        #region  public fields
        public Joystick curJoystick;
        public GameObject UI_Panel_Prefab_Ghost;
        public GameObject UI_Panel_Prefab_Ghostbuster;
        //public string NickName;
        public Button CooldownButton;
        private GameObject InstantiatedPanel;
        [SerializeField]
        GameObject minigames;
        [SerializeField]
        Animator myAnim;
        public CharecterClass CharecterClass { get => charecterClass; set { SwitchClass(value); } }

        public PlayerState PlayerState { get => playerState; set { ApplyState(value); } }
        #endregion

        #region Unity Functions
        private void Awake()
        {
            rb2d = GetComponent<Rigidbody2D>();
            col2d = GetComponent<Collider2D>();
            charecterClass = CharecterClass.GHOSTBUSTER;

        }
        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {

            if (stream.IsWriting)
            {
                stream.SendNext(rb2d.position);
                stream.SendNext(rb2d.rotation);
                stream.SendNext(rb2d.velocity);
            }
            else
            {
                rb2d.position = (Vector2)stream.ReceiveNext();
                rb2d.rotation = (float)stream.ReceiveNext();
                rb2d.velocity = (Vector2)stream.ReceiveNext();

                float lag = Mathf.Abs((float)(PhotonNetwork.Time - info.SentServerTime));
                rb2d.position += rb2d.velocity * lag;
            }


        }
        void Start()
        {
            if (charecterClass != CharecterClass.GHOSTBUSTER)
            {
                charecterClass = CharecterClass.GHOSTBUSTER;
                if (photonView.IsMine)
                {
                    myAnim = gameObject.GetComponent<Animator>();
                    //   GameObject temp= Instantiate(prefabInstatiate);
                    // temp.transform.SetParent(GameObject.Find("Canvas").GetComponent<Transform>(), false);


                    PlayerState = PlayerState.ALIVE;
                    curJoystick = FindObjectOfType<Joystick>();

                    InstantiatedPanel = Instantiate(UI_Panel_Prefab_Ghost, GameObject.Find("SafeArea").transform);


                    CooldownButton = InstantiatedPanel.transform.GetChild(0).GetComponent<Button>();
                    CooldownButton.onClick.AddListener(ActivatePhase);
                }
                
            }
            else 
            {
                charecterClass = CharecterClass.GHOST;
                myAnim = gameObject.GetComponent<Animator>();
                //   GameObject temp= Instantiate(prefabInstatiate);
                // temp.transform.SetParent(GameObject.Find("Canvas").GetComponent<Transform>(), false);


                PlayerState = PlayerState.ALIVE;
                curJoystick = FindObjectOfType<Joystick>();

                InstantiatedPanel = Instantiate(UI_Panel_Prefab_Ghostbuster, GameObject.Find("SafeArea").transform);


                CooldownButton = InstantiatedPanel.transform.GetChild(0).GetComponent<Button>();
                CooldownButton.onClick.AddListener(ActivatePhase);
            }


            CameraFollow _cameraWork = this.gameObject.GetComponent<CameraFollow>();


            if (_cameraWork != null)
            {
                if (photonView.IsMine)
                {
                    _cameraWork.OnStartFollowing();
                }
            }
            else
            {
                Debug.LogError("<Color=Red><a>Missing</a></Color> CameraWork Component on playerPrefab.", this);
            }




        }

        // Update is called once per frame
        void Update()
        {

        }
        private void FixedUpdate()
        {
            if (photonView.IsMine)
            {
                rb2d.velocity = curJoystick.Direction * speed;
            }
        }
        #endregion

        #region custom  functions
        IEnumerator SwitchStateCoolDown(PlayerState val = PlayerState.ALIVE, float t = 1f)
        {
            yield return new WaitForSeconds(t);
            PlayerState = val;
            CooldownButton.interactable = (true);
            //  CooldownButton.image.color = new Color(1f, 1f, 1f, 1f);

        }
        public void ActivatePhase()
        {
            PlayerState = PlayerState.PHASED;
            CooldownButton.interactable = (false);

            //  CooldownButton.image.color = new Color(0, 0, 0, 0.15f);
            // StartCoroutine(SwitchStateCoolDown(PlayerState.ALIVE, 3f));
        }

        void OnEnable()
        {

        }
        public void SwitchClass(CharecterClass val)
        {
            if (CharecterClass.GHOSTBUSTER == val)
            {
                charecterClass = CharecterClass.GHOSTBUSTER;
            }
            else
            {
                charecterClass = CharecterClass.GHOSTBUSTER;
            }
            //charecterClass = val;
            // myAnim.runtimeAnimatorController = Resources.Load("Animation/buster sprite sheet") as RuntimeAnimatorController;
            // Animator animator = Player 
            // switch animation parameters
            // switch sprites
            // switch powers


        }

        void ApplyState(PlayerState state)
        {
            playerState = state;
            //if (state != PlayerState.PHASED)
            //{
            //    gameObject.layer = LayerMask.NameToLayer("Default");
            //}

            switch (playerState)
            {
                case PlayerState.PHASED:
                    gameObject.layer = LayerMask.NameToLayer("Phased");
                    StartCoroutine(SwitchStateCoolDown(PlayerState.ALIVE, 3f));

                    break;


                case PlayerState.DEAD:
                    this.enabled = false;
                    gameObject.layer = LayerMask.NameToLayer("Default");

                    //play dead animation

                    break;
                case PlayerState.ALIVE:
                    gameObject.layer = LayerMask.NameToLayer("Default");


                    break;
                case PlayerState.SLOWED:
                    gameObject.layer = LayerMask.NameToLayer("Default");

                    break;
                case PlayerState.VULNARABLE:
                    gameObject.layer = LayerMask.NameToLayer("Default");


                    break;



            }
        }
        #endregion
        // Start is called before the first frame update

    }
}