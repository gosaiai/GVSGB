using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GVSGB
{
    public class PipeMovement : MonoBehaviour
    {
        #region private fields
        Vector2 ScreenBounds;
        #endregion
        #region public fields
        public float speed=10f;
        #endregion
        #region unity methods
        void Start()
        {
             ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(Vector3.left * speed*Time.deltaTime);
            if(transform.position.x< (-ScreenBounds.x))
            {
                Destroy(gameObject);
            }
        }


        void OnTriggerEnter2D(Collider2D collider)
        {
            if(collider.tag=="Bird")
            {

                Incantation.Instance.GameOver();
            }
        }
        private void OnDestroy()
        {
                Incantation.Instance.AddPoints();

        }
        #endregion
    }
}