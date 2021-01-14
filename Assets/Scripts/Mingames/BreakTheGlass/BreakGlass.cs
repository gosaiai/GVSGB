using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GVSGB
{


    public class BreakGlass : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private bool pointerDown;

        private float pointerDowmTimer;

        [SerializeField]
        private float pointerUpTimer = 3.0f;

        public float requiredHoldTime;

        public UnityEvent onLongClick;

        [SerializeField]
        private Image fillImage;


        public void OnPointerDown(PointerEventData eventData)
        {
            pointerDown = true;
            Debug.Log("OnPointerDown");

        }

        public void OnPointerUp(PointerEventData eventData)
        {
            pointerDown = false;

        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (pointerDown)
            {
                pointerDowmTimer += Time.deltaTime;
                if (pointerDowmTimer > requiredHoldTime)
                {
                    if (onLongClick != null)
                        onLongClick.Invoke();

                    Reset();
                }

                fillImage.fillAmount = pointerDowmTimer / requiredHoldTime;

            }

            else if (!pointerDown)
            {
                pointerUpTimer -= Time.deltaTime;




                if (pointerUpTimer < 0)
                {
                    Reset();
                }


                Debug.Log("OnPointerUp");
            }
        }


        private void Reset()
        {
            pointerDown = false;
            pointerDowmTimer = 0;
            pointerUpTimer = 2;
            fillImage.fillAmount = pointerDowmTimer / requiredHoldTime;


        }
    }
}
