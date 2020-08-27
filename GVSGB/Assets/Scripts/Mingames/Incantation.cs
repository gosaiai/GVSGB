using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GVSGB
{
    public class Incantation : MonoBehaviour
    {
        [SerializeField]
        MingameBase minigame;

        GameObject Bird;
        GameObject Pipes;

        float distaceBetween;

        float Speed;
        float JumpHeight;
        float Gravity;


        // Start is called before the first frame update
        void Start()
        {
            minigame = new MingameBase();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}