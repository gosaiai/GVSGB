
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GVSGB
{
    public class PipeMovement : MonoBehaviour
    {
        
        
        #region private fields

        Vector2 ScreenBounds;
        private Rigidbody2D rb;
        private Vector2 movement;

        #endregion
        #region public fields

        //public float speed=10f;
        public Transform bird;
        public float moveSpeed = 5f;
        

        #endregion
        #region unity methods
        void Start()
        {
             //ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
            rb = this.GetComponent<Rigidbody2D>();
            GameObject temp = GameObject.FindGameObjectWithTag("Bird");
            bird = temp.GetComponent<Transform>();

        }

        
        // Update is called once per frame
        void Update()
        {
            //transform.Translate(Vector3.left * speed*Time.deltaTime);
            Vector3 direction = bird.position - transform.position;
            //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            //rb.rotation = angle;
            direction.Normalize();
            movement = direction;
           
        }

        private void FixedUpdate()
        {
            moveCharacter(movement);
        }

        void moveCharacter(Vector2 direction)
        {
            rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
        }

        void OnTriggerEnter2D(Collider2D collider)
        {
            if(collider.tag=="Bird") //use the tag of collider u want to gameover to
            {
                Destroy(this.gameObject);
                Incantation.Instance.GameOver();
                Incantation.Instance.Restart();
            }
        }
        private void OnDestroy()
        {
                //Incantation.Instance.AddPoints();

        }
        #endregion
    }
}