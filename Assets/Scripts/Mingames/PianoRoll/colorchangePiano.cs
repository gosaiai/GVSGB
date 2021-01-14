using GVSGB;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;

namespace GVSGB
{
    public class colorchangePiano : MonoBehaviour
    {
        private SpriteRenderer renderer;
        public bool ifHit = false;
        bool pressed;
        
        MingameBase mingame;
        private void Start()
        {
            renderer = GetComponent<SpriteRenderer>();
            mingame = new MingameBase();
            
        }

        private void Update()
        {
            if (renderer.color == Color.black && Input.anyKeyDown)
            {
                AudioManager.instance.PlaySound("PianoRoll");
                MiniGameManager.instance.IncreaseSpooks();
                mingame.MyState = MiniGameState.FINISHED;
                if (Input.anyKeyDown)
                {
                    renderer.color = Color.white;
                }
            }

        }
       
        
      
        public void ColorChange()
        {
           
            renderer.color = Color.black;
        }
        public void stopColor()
        {
            renderer.color = Color.white;
        }


    }
}

