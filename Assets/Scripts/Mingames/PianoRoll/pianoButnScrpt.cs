using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GVSGB
{


    public class pianoButnScrpt : MonoBehaviour
    {

        public Button pianoBtn;

        private void Start()
        {
            pianoBtn.gameObject.SetActive(false);
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                Debug.Log("g");
                pianoBtn.gameObject.SetActive(true);

            }


           

        }

        public void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {

                pianoBtn.gameObject.SetActive(false);
            }
        }
    }
}
