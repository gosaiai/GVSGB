using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime; 

public class RoomListingMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    public Transform content;
    [SerializeField] 
    public RoomListing roomListing;

    private List<RoomListing> listings = new List<RoomListing>();
    private RoomsCanvases roomCanvases;
    
    public void FirstInitialize(RoomsCanvases canvases)
    {
        roomCanvases = canvases;
    }

    public override void OnJoinedRoom()
    {
        roomCanvases.CurrentRoomCanvas.Show();
        content.DestroyChildren();
        listings.Clear();
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach(RoomInfo info in roomList)
        {
            //Removed from room list
            if (info.RemovedFromList)
            {
                int index = listings.FindIndex(x => x.RoomInfo.Name == info.Name);
                if (index != -1)
                {
                    Destroy(listings[index].gameObject);
                    listings.RemoveAt(index);
                }
            }
            //Added to room list
            else
            {
                int index = listings.FindIndex(x => x.RoomInfo.Name == info.Name); 
                if(index == -1)
                {

                    RoomListing listing = Instantiate(roomListing, content);
                    if (listing != null)
                    {
                        listing.SetRoomInfo(info);
                        listings.Add(listing);
                    }
                }
                else
                {
                    //modify listing here
                    //ex.. listings[index].doWhatever
                }
                
            }
           
        }
    }

}
