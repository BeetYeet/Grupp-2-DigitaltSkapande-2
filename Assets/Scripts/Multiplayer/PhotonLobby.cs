using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonLobby : MonoBehaviourPunCallbacks
{
    public static PhotonLobby lobby;

    public GameObject startBattleButton, LoadningText;


    private void Awake()
    {
        lobby = this;        
    }
    // Start is called before the first frame update
    void Start()
    {
        startBattleButton.SetActive(false);
        LoadningText.SetActive(true);
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Conneted to the photon server");
        startBattleButton.SetActive(true);
        LoadningText.SetActive(false);
    }


    public void OnStartBattleButtonClicked()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("tried to join a room but no open rooms are active");
        CreateRoom();
    }

    void CreateRoom()
    {
        Debug.Log("creating room");
        int randomRoomId = Random.Range(0, 10000);
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 2 };
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.CreateRoom(randomRoomId.ToString(), roomOps);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log(message);
        CreateRoom();

    }

    public override void OnJoinedRoom()
    {
        Debug.Log("you are now in a room");
    }
}