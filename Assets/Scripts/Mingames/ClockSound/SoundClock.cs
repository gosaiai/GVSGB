using GVSGB;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundClock : MonoBehaviour
{
    public Button Play_SoundBtn;

    public Joystick stick;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Play_SoundBtn.gameObject.SetActive(true);


     
        }
    }
    private void Start()
    {

        Play_SoundBtn.gameObject.SetActive(false);
    }

    public void PlaySound()
    {
        AudioManager.instance.PlaySound("VOVOVO");
        stick.gameObject.SetActive(false);
        Play_SoundBtn.gameObject.SetActive(false);
        StartCoroutine(WaitTillSoundEnd());
    }

    IEnumerator WaitTillSoundEnd()
    {
        yield return new WaitForSeconds(3);
        stick.gameObject.SetActive(true);
        MiniGameManager.instance.IncreaseSpooks();
        Play_SoundBtn.gameObject.SetActive(true);

    }

}
