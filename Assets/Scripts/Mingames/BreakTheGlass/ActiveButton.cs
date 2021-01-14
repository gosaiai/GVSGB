using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveButton : MonoBehaviour
{

public GameObject glassbreakBtn;

        private void Start()
        {
            glassbreakBtn.SetActive(false);
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                Debug.Log("g");
                glassbreakBtn.SetActive(true);

            }


           

        }

        public void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {

                glassbreakBtn.gameObject.SetActive(false);
            }
        }
}
