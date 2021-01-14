using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GVSGB
{
    public class pentagramBtnScrpt : MonoBehaviour
    {
        public Button pentaBtn;

        private void Start()
        {
            pentaBtn.gameObject.SetActive(false);
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                Debug.Log("g");
                pentaBtn.gameObject.SetActive(true);

            }
        }

        public void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {

                pentaBtn.gameObject.SetActive(false);
            }
        }
    }
}