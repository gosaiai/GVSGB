﻿using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace GVSGB
{
    public class LevitateObject : Singleton<LevitateObject>
    {
        public GameObject startPanel;
        public GameObject successPanel;
        public GameObject failPanel;
        public GameObject book;
        public MingameBase miniGame;
        Rigidbody2D rb;
        float dirX;
        float dirY;
        public float moveSpeed = 10f;
        private Vector2 ScreenBounds;

        void Start()
        {
             ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

            rb = book.GetComponent<Rigidbody2D>();
            startPanel.SetActive(true);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (miniGame.MyState == MiniGameState.NOTSTARTED)
                {
                    miniGame.MyState = MiniGameState.INPROGRESS;
                    startPanel.SetActive(false);
                }
            }

            if(miniGame.MyState == MiniGameState.INPROGRESS)
            {
                dirX = Input.acceleration.x * moveSpeed;
                dirY = Input.acceleration.y * moveSpeed;                
                
            }
        }

        private void FixedUpdate()
        {
            rb.velocity = new Vector2(dirX,dirY);
            rb.position = new Vector2(Mathf.Clamp(rb.position.x, -ScreenBounds.x, ScreenBounds.x), Mathf.Clamp(rb.position.y, -ScreenBounds.y, ScreenBounds.y));
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.tag == "TargetArea")
            {
                successPanel.SetActive(true);
            }
        }
    }
}

