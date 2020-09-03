using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

namespace GVSGB
{


    public class circleSlider : MonoBehaviour
    {
        [SerializeField] public GameObject handle;
        private GameObject instantiatedHandle;
        [SerializeField] public float rotateSpeed;
        [SerializeField] public bool isPressed;
        [SerializeField] public AudioSource audioSource;
        [SerializeField] Vector3 spawnArea;

        [SerializeField] MiniGameState mystate = MiniGameState.NOTSTARTED;
        public AudioClip[] frequencies;
        public AudioClip tobeplayed;
        public AudioClip mainSound;
        MingameBase hauntRadio;


        public void Start()
        {
            hauntRadio = new MingameBase();
            audioSource = GetComponent<AudioSource>();
            instantiatedHandle = Instantiate(handle, spawnArea, Quaternion.identity);
        }

        public void PlayRandomSound()
        {
            int index = Random.Range(0, frequencies.Length);
            tobeplayed = frequencies[index];
            audioSource.clip = tobeplayed;
            audioSource.Play();
        }

        public void Update()
        {
            if (Input.GetMouseButton(0))
            {
                if (hauntRadio.MyState == MiniGameState.NOTSTARTED)
                {
                    hauntRadio.MyState = MiniGameState.INPROGRESS;
                    
                }

                if (hauntRadio.MyState == MiniGameState.INPROGRESS)
                {
                    instantiatedHandle.transform.Rotate(Vector3.forward * rotateSpeed);
                    float angle = instantiatedHandle.transform.eulerAngles.z;

                    if (angle > 0 && angle < 90)
                    {
                        PlayRandomSound();
                    }

                    else if (angle > 90 && angle < 180)
                    {
                        PlayRandomSound();
                    }
                    else if (angle > 180 && angle < 240)
                    {
                        PlayRandomSound();
                    }
                    else if (angle > 240 && angle < 360)
                    {
                        PlayRandomSound();
                    }
                    else if (tobeplayed = mainSound)
                    {
                        Debug.Log("complete");
                    }
                }
                   
                //transform.localRotation = Quaternion.Euler(0, 0, angle);
            }
            else
            {

            }
        }
    }
}
