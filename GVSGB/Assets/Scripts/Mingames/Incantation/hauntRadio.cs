using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;

using UnityEngine;

namespace GVSGB
{
    public class hauntRadio : MonoBehaviour
    {
        [SerializeField]
        MingameBase minigame;

        [SerializeField]
        GameObject needle;
        [SerializeField]
        GameObject points;

        [SerializeField]
        
        // Start is called before the first frame update
        void Start()
        {
            minigame = new MingameBase();
            
            
        }

        
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (minigame.MyState == MiniGameState.NOTSTARTED)
                {
                    minigame.MyState = MiniGameState.INPROGRESS;
                    
                }
            }
            if (minigame.MyState == MiniGameState.INPROGRESS)
            {

                if (Input.GetMouseButtonDown(0))
                {
                    
                }
                //if (Input.GetKeyDown(KeyCode.Space))
                //{
                //    CreatePipes();

                //}
                
            }
        }

       

      
    }
}