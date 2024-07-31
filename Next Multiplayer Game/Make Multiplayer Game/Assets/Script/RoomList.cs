using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RoomList : MonoBehaviourPunCallbacks
{
    public GameObject RoomPrefabs;
    public GameObject[] AllRooms;

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        for (int i = 0; i < AllRooms.Length; i++)
        {
            if (AllRooms[i] != null)
            {
                Destroy(AllRooms[i]);
            }
        }
        AllRooms = new GameObject[roomList.Count];

        for (int i = 0; i < roomList.Count; i++)
        {
            if (roomList[i].IsOpen && roomList[i].IsVisible && roomList[i].PlayerCount >= 1)
            {
                print(roomList[i].Name);
                GameObject Room = Instantiate(RoomPrefabs, Vector3.zero, Quaternion.identity, GameObject.Find("Content").transform);
                Room.GetComponent<Rooms>().roomName.text = roomList[i].Name;

                AllRooms[i] = Room;
            }
        }
    }
}
