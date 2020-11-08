using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GVSGB
{


    public class winCondition_Incantation : MonoBehaviour
    {
        public MiniGameManager spookMeter;
        private Slider spooks;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Bird")
            {
                Debug.Log("spook");
                spookMeter.IncreaseSpooks();
            }
        }
    }
}