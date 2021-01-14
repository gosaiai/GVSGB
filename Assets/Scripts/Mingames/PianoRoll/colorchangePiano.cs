using GVSGB;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GVSGB
{
    public class colorchangePiano : MonoBehaviour
    {
        private SpriteRenderer renderer;
        public bool ifHit = false;
      //  MiniGameManager miniMangaer;
       // GameObject pianoRef;
       // public pianoRoll finishedstate;
        MingameBase mingame;
        private void Start()
        {
            renderer = GetComponent<SpriteRenderer>();
            //pianoRef = GameObject.FindGameObjectWithTag("minigameManager");
            //miniMangaer = pianoRef.GetComponent<MiniGameManager>();
            //finishedstate = pianoRef.GetComponentInChildren<pianoRoll>();
            mingame = new MingameBase();
        }

        public void checkIfPressed()
        {
            if (Input.anyKey)
            {
                ifHit = true;
                Debug.Log("Pressed primary button.");
                
                if (ifHit == true)
                {
                    AudioManager.instance.PlaySound("PianoRoll");
                    MiniGameManager.instance.IncreaseSpooks();
                    mingame.MyState = MiniGameState.FINISHED;
                    //finishedstate.FinishedState();
                }
            }

        }


        public void ColorChange()
        {
            if (Input.GetKeyDown(0))
            {
                Debug.Log("hit");
                ifHit = true;
            }

            if (ifHit == true)
            {
                Debug.Log("++");
            }
            renderer.color = Color.black;
        }
        public void stopColor()
        {
            renderer.color = Color.white;
        }


    }
}

