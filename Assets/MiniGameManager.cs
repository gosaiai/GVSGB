using GVSGB;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GVSGB
{
    public class MiniGameManager : Singleton<MiniGameManager>
    {

        public List<MingameBase> AllMiniGames = new List<MingameBase>();
        [SerializeField]

        GameObject mainCamera;
        [SerializeField]
        GameObject miniGameCamera;
        // Start is called before the first frame update
        void Start()
        {

        }
        public void SwitchTOMiniGame()
        {
            mainCamera.SetActive(false);

            miniGameCamera.SetActive(true);



        }
        public void SwitchToMainGame()
        {
            mainCamera.SetActive(true);
            miniGameCamera.SetActive(false);
        }
        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                SwitchTOMiniGame();
                //  AllMiniGames[0].game.SetActive(true);
                DrawPentagram.Instance.gameObject.SetActive(true);
            }
            if (Input.GetMouseButtonDown(1))
            {
                SwitchToMainGame();
            }
        }
    }
}
