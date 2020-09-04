using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class LongClickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isPointerDown;
    private float pointerDownTimer;

    [SerializeField]
    private float holdTimeRequired;

    public UnityEvent onLongClick;

    [SerializeField]
    private Image fillImage;

    public GameObject failScreen;
    public void OnPointerDown(PointerEventData eventData)
    {
        isPointerDown = true;
        Debug.Log("Pointer down");
    }

    //Task failed and reset progress is button released
    public void OnPointerUp(PointerEventData eventData)
    {
        Reset();
        Debug.Log("PointerUp");
    }

    // Update is called once per frame
    void Update()
    {
        //Increases progress while button is pressed 
        if(isPointerDown)
        {
            pointerDownTimer += Time.deltaTime;
            if (pointerDownTimer > holdTimeRequired)
            {
                if (onLongClick != null)
                {
                    onLongClick.Invoke();
                }

                Reset();
            }

            fillImage.fillAmount = pointerDownTimer / holdTimeRequired;
        }
    }

    //Resets the progress and task is failed
    private void Reset()
    {
        isPointerDown = false;
        pointerDownTimer = 0;
        fillImage.fillAmount = pointerDownTimer / holdTimeRequired;
        failScreen.SetActive(true);
    }
}
