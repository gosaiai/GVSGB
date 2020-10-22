using GVSGB;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class temp_gameSwitch : MonoBehaviour
{
    public GameObject[] currentGame;
    public GameObject successPanel;
    public GameObject failPanel;
    int index = 0;
    private int running_game;
    private void Start()
    {
        
    }

    public void goToNext()
    {
        successPanel.SetActive(false);
        failPanel.SetActive(false);
        currentGame[index].SetActive(false);
        index++;
        if(index >= currentGame.Length)
        {
            index = 0;
            
        }
        currentGame[index].SetActive(true);

    }
}

