using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GVSGB
{
    public class press2poopBtn : MonoBehaviour
    {
        public GameObject press2pooBtn;

        private void Start()
        {
            press2pooBtn.SetActive(false);
        }
        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                Debug.Log("g");
                press2pooBtn.SetActive(true);

            }




        }

        public void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {

                press2pooBtn.SetActive(false);
            }
        }

    }
}