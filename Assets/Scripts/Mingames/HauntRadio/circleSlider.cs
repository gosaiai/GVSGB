using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class circleSlider : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] Transform handle;
    [SerializeField] public float rotateSpeed;
    [SerializeField] public bool isPressed;
    [SerializeField] public AudioSource audioSource;
    Transform angle;

    public void Start()
    {
       
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }

    public void PlayAudio()
    {
        audioSource.Play();
    }

    public void Update()
    {
        if (isPressed)
        {
            handle.transform.Rotate(Vector3.forward * rotateSpeed);
            audioSource = GetComponent<AudioSource>();
            audioSource.Play(0);
        }
        else
        {
            audioSource.Pause();
        }
    }
}
