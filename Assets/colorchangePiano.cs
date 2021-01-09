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

        private void Start()
        {
            renderer = GetComponent<SpriteRenderer>();

        }

        public void checkIfPressed()
        {
            if (Input.anyKey)
            {
                ifHit = true;
                Debug.Log("Pressed primary button.");
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

