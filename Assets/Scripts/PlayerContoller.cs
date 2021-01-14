using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System;

namespace GVSGB
{

    [RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
    public class PlayerContoller : MonoBehaviourPun
    {
        // Start is called before the first frame update

        #region Private Fields
        /// <summary>
        /// animaiotion controller of obj
        /// </summary>
        [SerializeField]
        Animator MyAnim;

        [SerializeField]
        GameObject prefabInstatiate;
        /// <summary>
        ///  the joy  stick  in the scene
        /// </summary>
        [SerializeField]
        public Joystick activeJoyStick;
        /// <summary>
        /// Obj 2D collider
        /// </summary>
        Collider2D myC2D;
        /// <summary>
        /// obj Rigid body 2D
        /// </summary>
        Rigidbody2D myRB2D;

        #endregion
        #region Public Fields
        /// <summary>
        /// active player speed
        /// </summary>
        [SerializeField]
        [Tooltip("Speed of player")]
        float speed = 10;
        #endregion

        #region MonoBehaviour CallBacks
        void Start()
        {
            if (photonView.IsMine)
            {
                //   GameObject temp= Instantiate(prefabInstatiate);
                // temp.transform.SetParent(GameObject.Find("Canvas").GetComponent<Transform>(), false);
                activeJoyStick = FindObjectOfType<Joystick>();

                myRB2D = GetComponent<Rigidbody2D>();
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
            myC2D = GetComponent<Collider2D>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {

            if (photonView.IsMine == false && PhotonNetwork.IsConnected == true)
            {
                return;
            }
            if (activeJoyStick == null)
            {
                //FindRefrence();
            }
            myRB2D.AddForce(activeJoyStick.Direction * speed * Time.fixedDeltaTime, ForceMode2D.Force);
            if (activeJoyStick.Horizontal < 0)
            {
                transform.rotation=Quaternion.Euler(0, 180, 0);
            }
            if (activeJoyStick.Horizontal > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            if (activeJoyStick.Direction != Vector2.zero)
            {
                MyAnim.SetBool("is_Moving", true);
            }
            else
            {
                MyAnim.SetBool("is_Moving", false);
            }
        }

        private void FindRefrence()
        {
            activeJoyStick = FindObjectOfType<Joystick>();
        }
        #endregion untiy callBacks
    }
}