using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class RandomCustomPropertyGenerator : MonoBehaviour
{
    [SerializeField]
    private Text text;

    private ExitGames.Client.Photon.Hashtable myCustomProperties = new ExitGames.Client.Photon.Hashtable();
   
    private void SetCustomNumber()
    {
        System.Random rnd = new System.Random();
        int result = rnd.Next(0, 99);

        text.text = result.ToString();

        myCustomProperties["RandomNumber"] = result;
        PhotonNetwork.SetPlayerCustomProperties(myCustomProperties);
        //PhotonNetwork.LocalPlayer.CustomProperties = myCustomProperties;
    }

    public void OnClick_Button()
    {
        SetCustomNumber();
    }

    
}
