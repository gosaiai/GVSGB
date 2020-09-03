using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace GVSGB
{
    public class FixPotrait : Singleton<FixPotrait>
    {
        #region Private  Fields
        MiniGameState myState;
        [Range(-45, 45)]
        int rotRange;

        Vector3 MouseStartPoint;

        #endregion

        #region Public Fields

        public GameObject RotatingObj;
        public GameObject GoalRotation;
        public GameObject StartPanel;
        public GameObject SuccessPanel;
        #endregion
        #region GameLogic
        void InitGame()
        {
            rotRange = Random.Range(-45, 46);
            if (rotRange == 0)
            {
                rotRange = 10;
            }
            GoalRotation.transform.localRotation = Quaternion.Euler(GoalRotation.transform.localRotation.x, GoalRotation.transform.localRotation.y, rotRange);

            StartPanel.SetActive(false);
        }

        bool CheckRotation()
        {
            if (GoalRotation.transform.localRotation == RotatingObj.transform.localRotation)
            {
                return true;
            }
            return false;
        }

        #endregion
        Vector3 GetSwipeDirection()
        {
            return (MouseStartPoint - (Camera.main.ScreenToWorldPoint(Input.mousePosition))).normalized;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="is_left"> will rotate left?</param>
        void RotateInDirection(bool is_left = true)
        {

            if (is_left)
                RotatingObj.transform.Rotate(0, 0, 1);
            else
                RotatingObj.transform.Rotate(0, 0, -1);

            //RotatingObj.transform.localRotation = Quaternion.Euler(RotatingObj.transform.localRotation.x, RotatingObj.transform.localRotation.y, RotatingObj.transform.localRotation.z - 1f);

        }

        #region Unity Functions
        // Start is called before the first frame update
        void Start()
        {
            // InitGame();
            StartPanel.SetActive(true);

        }

        // Update is called once per frame
        void Update()
        {
            if (myState == MiniGameState.NOTSTARTED)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    myState = MiniGameState.INPROGRESS;
                    InitGame();
                    
                }
            }
            if (myState == MiniGameState.INPROGRESS)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    MouseStartPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                }

                if (Input.GetMouseButton(0))
                {
                    if (GetSwipeDirection().x < 0)
                    {
                        RotateInDirection(false);

                    }
                    if (GetSwipeDirection().x > 0)
                    {
                        RotateInDirection(true);

                    }
                }
                if (Input.GetMouseButtonUp(0))
                {
                    MouseStartPoint = Vector3.zero;
                    if (CheckRotation())
                    {
                        myState = MiniGameState.FINISHED;
                        SuccessPanel.SetActive(true);
                    }
                }
            }
        }

        #endregion
    }
}