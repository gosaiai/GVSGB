using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateOrJoinRoomCanvas : MonoBehaviour
{
    [SerializeField]
    private CreateRoomMenu createRoomMenu;
    [SerializeField]
    private RoomListingMenu roomListingMenu;

    private RoomsCanvases roomCanvases;

    public void FirstInitialize(RoomsCanvases canvases)
    {
        roomCanvases = canvases;
        createRoomMenu.FirstInitialize(canvases);
        roomListingMenu.FirstInitialize(canvases);
    }
}
