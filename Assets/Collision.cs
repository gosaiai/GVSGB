using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public GameObject successPanel;
    public GameObject failPanel;

    private float holdTime = 3f;
    private float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime >= holdTime)
        {
            successPanel.SetActive(true);
            currentTime = 0;
        }
       
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TargetArea")
        {
            currentTime += Time.deltaTime;
            Debug.Log(currentTime);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TargetArea")
        {
            failPanel.SetActive(true);
        }
    }
}
