using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GVSGB
{
    public class TicTacToe : Singleton<TicTacToe>
    {
        #region public Fields
        public bool is_XTurn = false;
        // Start is called before the first frame update
        public Box[] allBoxes;
        public MingameBase mingame;
        public GameObject starPanel;
        public GameObject successPanel;

        public GameObject failPanel;
        #endregion
        #region GameLogic
        /// <summary>
        /// switches tile  piece  and checks game over at thesame time
        /// </summary>
        public void SwitchTurn()
        {
            is_XTurn = !is_XTurn;

            GameChecks();
        }
        void GameChecks()
        {
            if (CheckIfWinTacToe())
            {
                mingame.MyState = MiniGameState.FAILED;
                failPanel.SetActive(true);

                return;
            }
            if (CheckIfAllFull())
            {
                mingame.MyState = MiniGameState.FINISHED;
                successPanel.SetActive(true);
            }
        }
        public bool CheckIfWinTacToe()
        {
            ///diagonal
            ///048
            ///246
            ///collumn
            ///036
            ///147
            ///258
            ///row
            ///012
            ///345
            ///678
            ///
            return (CheckCollumns() || CheckRows() || CheckDiagonal());


        }

        public bool CheckIfAllFull()
        {
            bool retVal = true;
            for (int i = 0; i < 9; i++)
            {
                retVal &= allBoxes[i].IsHolding;
                if (retVal == false)
                {
                    return retVal;
                }
            }

            return retVal;
        }
        void RandomlyFillAFewBoxes(int count = 2)
        {
            for (int i = 0; i < count; i++)
            {
                int x = Random.Range(0, 9);
                while (allBoxes[x].IsHolding == true)
                {
                    x = Random.Range(0, 9);
                }
                if (is_XTurn)
                {
                    allBoxes[x].Holding = TicTacToeBox.X;
                }
                else
                {
                    allBoxes[x].Holding = TicTacToeBox.O;
                }
                allBoxes[x].IsHolding = true;
                SwitchTurn();
            }
        }
        bool CheckDiagonal()
        {

            int i = 0;

            if (allBoxes[i].Holding != TicTacToeBox.EMPTY && allBoxes[i + 4].Holding != TicTacToeBox.EMPTY && allBoxes[i + 8].Holding != TicTacToeBox.EMPTY)
            {
                if ((allBoxes[i].Holding == allBoxes[i + 4].Holding) && allBoxes[i].Holding == allBoxes[i + 8].Holding)
                {
                    return true;
                }
            }

            i = 2;

            if (allBoxes[i].Holding != TicTacToeBox.EMPTY && allBoxes[i + 2].Holding != TicTacToeBox.EMPTY && allBoxes[i + 4].Holding != TicTacToeBox.EMPTY)
            {
                if ((allBoxes[i].Holding == allBoxes[i + 2].Holding) && allBoxes[i].Holding == allBoxes[i + 4].Holding)
                {
                    return true;
                }
            }



            return false;
        }
        bool CheckCollumns()
        {

            for (int i = 0; i < 3; i++)
            {
                if (allBoxes[i].Holding != TicTacToeBox.EMPTY && allBoxes[i + 3].Holding != TicTacToeBox.EMPTY && allBoxes[i + 6].Holding != TicTacToeBox.EMPTY)
                {
                    if ((allBoxes[i].Holding == allBoxes[i + 3].Holding) && allBoxes[i].Holding == allBoxes[i + 6].Holding)
                    {
                        return true;
                    }
                }

            }
            return false;
        }
        bool CheckRows()
        {

            for (int i = 0; i < 9; i += 3)
            {
                if (allBoxes[i].Holding != TicTacToeBox.EMPTY && allBoxes[i + 1].Holding != TicTacToeBox.EMPTY && allBoxes[i + 2].Holding != TicTacToeBox.EMPTY)
                {
                    if ((allBoxes[i].Holding == allBoxes[i + 1].Holding) && allBoxes[i].Holding == allBoxes[i + 2].Holding)
                    {
                        return true;
                    }
                }

            }
            return false;
        }

        #endregion
        void Start()
        {
            starPanel.SetActive(true);
            RandomlyFillAFewBoxes(Random.Range(0, 3));
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (mingame.MyState == MiniGameState.NOTSTARTED)
                {
                    mingame.MyState = MiniGameState.INPROGRESS;
                    starPanel.SetActive(false);

                }
            }
        }
    }
}