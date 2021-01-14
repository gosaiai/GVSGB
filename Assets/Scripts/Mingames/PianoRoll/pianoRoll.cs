using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GVSGB
{
    public class pianoRoll : MonoBehaviour
    {
        [SerializeField]
        public Joystick stick;
        public float waitTime = 5;
        public GameObject pianoKeyPos;
        private GameObject clone;
        public GameObject pianoBtn;
        MingameBase minigame;
        public void startGame()
        {
            minigame = new MingameBase();
            //minigame.MyState = MiniGameState.NOTSTARTED;
            //circle.SetActive(true);
            Debug.Log(minigame.MyState);
            doSpook();
            //incantation.SetActive(true);
        }
        IEnumerator spookTime()
        {
            yield return new WaitForSeconds(waitTime);
            stick.gameObject.SetActive(true);
            Destroy(clone);
            pianoBtn.SetActive(true);
        }
        public void FinishedState()
        {
            minigame.MyState = MiniGameState.FINISHED;
        }
        public void doSpook()
        {
            if (minigame.MyState == MiniGameState.NOTSTARTED)
            {
                minigame.MyState = MiniGameState.INPROGRESS;
                
                if (minigame.MyState == MiniGameState.INPROGRESS)
                {
                    stick.gameObject.SetActive(false);
                    CircleDraw();
                    pianoBtn.SetActive(false);
                    Debug.Log("spook");
                    StartCoroutine(spookTime());
                }
            }
           
            
        }
        
        
        void CircleDraw()
        {

             clone = Instantiate(Resources.Load("circle"), (new Vector3((UnityEngine.Random.Range(0, 7)), 1, 0)), pianoKeyPos.transform.rotation) as GameObject;
       

        }
    }
}
