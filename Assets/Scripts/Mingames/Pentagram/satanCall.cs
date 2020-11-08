using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GVSGB
{


    public class satanCall : MonoBehaviour
    {
        public CircleCollider2D upPentagram;
        public CircleCollider2D downPentagram;

        void Start()
        {
            var colliders = GetComponents<CircleCollider2D>();
            upPentagram = colliders[0];
            downPentagram = colliders[1];
        }

        // Update is called once per frame
        void Update()
        {

        }
        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.IsTouching(upPentagram))
            {
                Debug.Log("side");
            }
            else if (collider.IsTouching(downPentagram))
            {
                Debug.Log("jump");
            }
        }
    }
}