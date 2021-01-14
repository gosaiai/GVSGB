using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GVSGB
{
    public class PickObject : MonoBehaviour
    {
        public GameObject pandD_btn;

        public TextMeshProUGUI buttontext;


        private Transform taker;

        public bool btn_check;


        public static bool pickanddrop { get; set; }


        // Use this for initialization
        void Start()
        {
            pickanddrop = false;
            pandD_btn.SetActive(false);


        }

        // Update is called once per frame
        void Update()
        {
            if (pickanddrop)
            {



                buttontext.text = "Drop";

            }
            else
            {
                buttontext.text = "Pick UP";
            }


        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                pandD_btn.SetActive(true);
                taker = collision.transform;

            }
        }


        private void OnTriggerExit2D(Collider2D collision)
        {

            if (collision.CompareTag("Player"))
            {
                if(!pickanddrop)
                {
                    pandD_btn.SetActive(false);
                    taker = null;

                }
            }
        }

        public void ButtonMng()
        {
            pickanddrop = !pickanddrop;
            if (pickanddrop)
            {
                PickUP();


            }
            else
            {
                Drop();

            }
        }



        void PickUP()
        {

            transform.parent = taker;

            pickanddrop = true;
            Debug.Log("Picked!");
        }

        void Drop()
        {
            pandD_btn.SetActive(false);
            transform.parent = null;
            taker = null;

           
            pickanddrop = false;
            Debug.Log("Drop!");
        }
    }
}