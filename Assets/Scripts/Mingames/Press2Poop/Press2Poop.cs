using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.SocialPlatforms;



namespace GVSGB
{
    public class Press2Poop : Singleton<Press2Poop>
    {
        #region Public variables
        public MingameBase miniGame;
        public GameObject startPanel;
        public GameObject successPanel;
        public GameObject failPanel;
        #endregion

        #region Private variables
        private float targetProgress = 1;
        private bool isPressed = false;
        #endregion


        #region UnityFunctions
        // Start is called before the first frame update
        void Start()
        {
            startPanel.SetActive(true);           
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (miniGame.MyState == MiniGameState.NOTSTARTED)
                {
                    miniGame.MyState = MiniGameState.INPROGRESS;
                    startPanel.SetActive(false);
                }
               
            }        
        }
     
        #endregion
    }
}

