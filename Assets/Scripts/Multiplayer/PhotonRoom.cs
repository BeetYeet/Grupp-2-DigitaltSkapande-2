﻿using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhotonRoom : MonoBehaviourPunCallbacks, IInRoomCallbacks
{
    //Room info
    public static PhotonRoom room;
    private PhotonView PV;

    // public bool isGameLoaded;
    public int currectScene;
    public int MultiplayerScene;


    Player info;
    Player[] photonPlayers;

    public int playersInRoom;
    public int myNumberInRoom;
    public int playersInGame;


    private void Awake()
    {
        if (PhotonRoom.room == null)
        {
            PhotonRoom.room = this;
        }
        else
        {
            if (PhotonRoom.room != this)
            {
                UnityEngine.Object.Destroy(PhotonRoom.room.gameObject);
                PhotonRoom.room = this;
            }
        }


    }

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        PV = GetComponent<PhotonView>();
        SceneManager.sceneLoaded += OnSceneFinishedLoading;

    }


    public override void OnEnable()
    {
        //subscribe to functions
        base.OnEnable();
        PhotonNetwork.AddCallbackTarget(this);

    }
    public override void OnDisable()
    {
        base.OnDisable();
        PhotonNetwork.RemoveCallbackTarget(this);
        SceneManager.sceneLoaded -= OnSceneFinishedLoading;
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("now Inside a room");
        StartGame();

        photonPlayers = PhotonNetwork.PlayerList;
        playersInRoom = photonPlayers.Length;
        myNumberInRoom = playersInRoom;
        PhotonNetwork.NickName = myNumberInRoom.ToString();


    }
    private void Update()
    {

    }


    void StartGame()
    {
        Debug.Log("Loading Level");

        PhotonNetwork.LoadLevel(MultiplayerScene);

    }
    void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode)
    {

        if (SceneManager.GetActiveScene() == scene)
        {
            CreatePlayer();
        }

    }

    private void CreatePlayer()

    {/// needs prefab name
        PhotonNetwork.Instantiate("Player", transform.position, Quaternion.identity, 0);

    }
}
