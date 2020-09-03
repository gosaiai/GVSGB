using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GVSGB
{
    public class NumberTile : MonoBehaviour
    {

        #region Pubic Fields
        public TextMeshPro displayNumber;
        public int myNumber;
        public SpriteRenderer myBackGround;
        #endregion
        #region GameLogic Functions
        public void AssignMyNumber()
        {
            displayNumber.text = myNumber.ToString();
        }
        public void ChangeColor(Color change)
        {
            myBackGround.color = change;
        }

        #endregion

        #region Unity Methods
        // Start is called before the first frame update
        void Start()
        {
            //AssignMyNumber();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnMouseDown()
        {
            if (ArrangeNumbers.Instance.myMinigame.MyState == MiniGameState.INPROGRESS)
            {
                ArrangeNumbers.Instance.RecieveNumber(this);
            }
        }
        #endregion
    }
}