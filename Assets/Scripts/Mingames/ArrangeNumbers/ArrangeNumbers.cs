using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GVSGB
{
    public class ArrangeNumbers : Singleton<ArrangeNumbers>
    {
        #region Public Fields
        public GameObject StarGamePanel;
        public GameObject SuccessPanel;
        public MingameBase myMinigame;
        public GameObject FailPanel;

        public int oldNumber = 0;
        public NumberTile[] AllNumbers;
        #endregion

        #region Private Fields

        #endregion

        #region Gamelogic methods 
        void AssignNumbers()
        {
            List<int> numberToAssign = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            for (int i = 0; i < 10; i++)
            {
                int temp = Random.Range(0, numberToAssign.Count);
                AllNumbers[i].myNumber = numberToAssign[temp];
                numberToAssign.RemoveAt(temp);
                AllNumbers[i].AssignMyNumber();
            }
        }

        bool CheckIfTaskOver()
        {
            if (oldNumber == 10)
            {

                return true;
            }
            return false;
        }
        void ResetAll()
        {
            foreach (NumberTile j in AllNumbers)
            {
                j.ChangeColor(Color.white);


            }
            oldNumber = 0;
            StarGamePanel.SetActive(true);
        }
        public void RecieveNumber(NumberTile number)
        {
            if (number.myNumber - oldNumber <= 0 || number.myNumber - oldNumber > 1)
            {
                number.ChangeColor(Color.red);
                myMinigame.MyState = MiniGameState.FAILED;
                FailPanel.SetActive(true);

            }
            if (number.myNumber - oldNumber == 1)
            {
                number.ChangeColor(Color.green);
                oldNumber = number.myNumber;

            }
        }

        #endregion

        #region Unity Methods
        // Start is called before the first frame update
        void Start()
        {
            StarGamePanel.SetActive(true);
            AssignNumbers();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if ( myMinigame.MyState != MiniGameState.INPROGRESS || myMinigame.MyState != MiniGameState.FINISHED)
                {
                    if (myMinigame.MyState == MiniGameState.FAILED)
                    {
                        ResetAll();
                        
                    }
                    StarGamePanel.SetActive(false);
                    myMinigame.MyState = MiniGameState.INPROGRESS;

                }
            }
            if (myMinigame.MyState == MiniGameState.INPROGRESS)
            {
                if (CheckIfTaskOver())
                {
                    myMinigame.MyState = MiniGameState.FINISHED;
                    SuccessPanel.SetActive(true);
                }
            }
        }
        #endregion
    }
}