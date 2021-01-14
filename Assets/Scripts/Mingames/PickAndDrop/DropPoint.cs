using GVSGB;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class DropPoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Found Drop Point.....??????");

           if(PickObject.pickanddrop== true)
            {
                MiniGameManager.instance.IncreaseSpooks();

                Debug.Log("Found Drop Point.....");
            }

        }
    }
}
