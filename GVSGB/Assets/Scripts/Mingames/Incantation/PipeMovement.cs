using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GVSGB
{
    public class PipeMovement : MonoBehaviour
    {
        public float speed=10f;

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(Vector3.left * speed*Time.deltaTime);
        }
    }
}