using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GVSGB
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
    public class Player : MonoBehaviour
    {
        #region  private fields
        [SerializeField]
        float speed;
        Rigidbody2D rb2d;
        Collider2D col2d;
        private PlayerState playerState = PlayerState.DEAD;
        private CharecterClass charecterClass = CharecterClass.GHOST;
        #endregion
        #region  public fields
        public Joystick curJoystick;
        public GameObject Panel;

        public CharecterClass CharecterClass { get => charecterClass; set { SwitchClass(value); } }

        public PlayerState PlayerState { get => playerState; set { ApplyState(value); } }
        #endregion

        #region Unity Functions
        private void Awake()
        {
            rb2d = GetComponent<Rigidbody2D>();
            col2d = GetComponent<Collider2D>();


        }
        void Start()
        {
            PlayerState = PlayerState.ALIVE;
        }

        // Update is called once per frame
        void Update()
        {

        }
        private void FixedUpdate()
        {

            rb2d.velocity = curJoystick.Direction * speed;

        }
        #endregion

        #region custom  functions
        IEnumerator SwitchStateCoolDown(PlayerState val = PlayerState.ALIVE, float t = 1f)
        {
            yield return new WaitForSeconds(t);
            PlayerState = val;

        }
        public void ActivatePhase()
        {
            PlayerState = PlayerState.PHASED;
           // StartCoroutine(SwitchStateCoolDown(PlayerState.ALIVE, 3f));
        }


        void SwitchClass(CharecterClass val)
        {
            charecterClass = val;
            /// switch animation parameters
            /// switch sprites
            /// switch powers


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