using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;

using UnityEngine;

namespace GVSGB
{
    public class Incantation : MonoBehaviour
    {
        [SerializeField]
        MingameBase minigame;

        [SerializeField]
        GameObject Bird;
        [SerializeField]
        GameObject Pipes;

        private GameObject activeBird;
        public Transform StartPos;

        float distaceBetween;

        //  float Speed;
        [SerializeField]
        float JumpForce;
        [SerializeField]
        float Gravity;

        [SerializeField]
        const float SizeToFillScreen = 3;
        [SerializeField]
        float MaxDistanceBetweenPipes;

        [SerializeField]
        float MinDistanceBetweenPipes;
        float PipeMovementSpeed;
        // Start is called before the first frame update
        void Start()
        {
            minigame = new MingameBase();
            PipeMovementSpeed = Pipes.GetComponent<PipeMovement>().speed;
            if (StartPos == null)
            {
                throw new System.NullReferenceException("StarPos not  set");
            }
            InitGame();
        }

        float GetwaitTime()
        {
            if (UnityEngine.Random.Range(0, 2) == 0)
            {
                return MinDistanceBetweenPipes / PipeMovementSpeed;
            }
            else
            {
                return MaxDistanceBetweenPipes / PipeMovementSpeed;
            }
        }

        void StartSpawnPipes()
        {
            StartCoroutine(Spawner());
        }
        IEnumerator  Spawner()
        {
            yield return new WaitForSeconds(GetwaitTime());
            CreatePipes();
            StartSpawnPipes();
        }    
        #region  private METHODS
        void InitGame()
        {
            activeBird = Instantiate(Bird, StartPos.position, Quaternion.identity);


        }
        #endregion
        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (minigame.MyState == MiniGameState.NOTSTARTED)
                {
                    minigame.MyState = MiniGameState.INPROGRESS;
                    StartSpawnPipes();
                }
            }
            if (minigame.MyState == MiniGameState.INPROGRESS)
            {

                if (Input.GetMouseButtonDown(0))
                {
                    activeBird.transform.Translate(Vector2.up * JumpForce * Time.deltaTime);
                }
                //if (Input.GetKeyDown(KeyCode.Space))
                //{
                //    CreatePipes();

                //}
                activeBird.transform.Translate(Vector2.down * Gravity * Time.deltaTime);
            }
        }

        void CreatePipes()
        {
            float minGap = 1f;
            Vector2 ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

            GameObject pipe1 = Instantiate(Pipes);
            pipe1.transform.position = new Vector3(ScreenBounds.x, ScreenBounds.y, 0f);

            GameObject pipe2 = Instantiate(Pipes);
            pipe2.transform.position = new Vector3(ScreenBounds.x, -ScreenBounds.y, 0f);
            pipe2.transform.localScale = new Vector3(pipe2.transform.localScale.x, -pipe2.transform.localScale.y, pipe2.transform.localScale.z);

            float val = GetOneScaleValue(1, SizeToFillScreen);

            if (UnityEngine.Random.Range(0, 2) == 0)
            {
                pipe1.transform.localScale = new Vector2(pipe1.transform.localScale.x, val);
                pipe2.transform.localScale = new Vector2(pipe2.transform.localScale.x, -(SizeToFillScreen - val));
            }
            else
            {
                pipe1.transform.localScale = new Vector2(pipe1.transform.localScale.x, (SizeToFillScreen - val));
                pipe2.transform.localScale = new Vector2(pipe2.transform.localScale.x, -val);
            }
            //  pipe1.transform.Translate(Vector3.left* PipeSpeed);
        }

        float GetOneScaleValue(float MinPipeHight = 1, float MaxPipeHeight = SizeToFillScreen)
        {
            Vector2 ret = Vector2.Lerp(Vector2.left * MinPipeHight, Vector2.left * MaxPipeHeight, UnityEngine.Random.Range(0.25f, 1f));
            return Mathf.Abs(ret.x);
        }
    }
}