using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GVSGB
{
    [RequireComponent(typeof(BoxCollider2D))]  
    public class Box : MonoBehaviour
    {
        #region public Fields
        private TicTacToeBox holding = TicTacToeBox.EMPTY;
        public bool IsHolding = false;
        public SpriteRenderer rend;
        public Sprite bone;
        public Sprite skull;

        public TicTacToeBox Holding
        {

            get => holding;
            set
            {
                holding = value;
                SwitchColor();
            }

        }
        #endregion
        #region SwitchColor
        void SwitchColor()
        {

            switch (holding)
            {

                case TicTacToeBox.X:
                    //rend.color = Color.red;
                    GetComponent<SpriteRenderer>().sprite = bone;

                    break;
                case TicTacToeBox.O:
                    //rend.color = Color.green;
                    rend.GetComponent<SpriteRenderer>().sprite = skull;
                    break;

                default:
                   rend.color = Color.white;
                    break;

            }

        }
        #endregion


        #region Unity methods
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        private void OnMouseDown()
        {
            if (TicTacToe.Instance.mingame.MyState != MiniGameState.INPROGRESS)
            { return; }
            if (!IsHolding)
            {
                IsHolding = true;
                if (TicTacToe.Instance.is_XTurn)
                {
                    holding = TicTacToeBox.X;
                }
                else
                {
                    holding = TicTacToeBox.O;
                }
                TicTacToe.Instance.SwitchTurn();
                SwitchColor();

            }
        }
        #endregion
    }
}