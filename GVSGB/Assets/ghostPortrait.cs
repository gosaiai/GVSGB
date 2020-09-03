using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GVSGB
{
    public class ghostPortrait : MonoBehaviour
    {
        [SerializeField] public GameObject frame;
        [SerializeField] MiniGameState mystate = MiniGameState.NOTSTARTED;
        [SerializeField] MingameBase GhostPortrait;
        [SerializeField] Vector3 area;
        [SerializeField] public float timeRemaining = 5f;
        bool keepTime;

        private void Start()
        {
            GhostPortrait = new MingameBase();
            Instantiate(frame, area, Quaternion.identity);
            startTimer();

        }

        void startTimer()
        {
            keepTime = true;
            timeRemaining -= Time.deltaTime;
        }

        float stopTimer()
        {
            keepTime = false;
                return timeRemaining;
        }
        private void Update()
        {
            if (GhostPortrait.MyState == MiniGameState.NOTSTARTED)
            {
                GhostPortrait.MyState = MiniGameState.INPROGRESS;
            }
            
            else if (GhostPortrait.MyState == MiniGameState.INPROGRESS)
            {
                if (keepTime)
                {
                    startTimer();
                }
                if (timeRemaining > 0 && Input.GetMouseButton(0))
                {
                    stopTimer();
                    Debug.Log("failed");
                    
                }
                else if (timeRemaining > 5 && Input.GetMouseButton(0))
                {
                    Debug.Log("done");
                }
            }
        }
    }
}
