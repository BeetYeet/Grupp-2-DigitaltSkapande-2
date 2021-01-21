using Photon.Pun;
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
    public string IGN;
    public Vector2Int IGN_limit;
    public GameObject PlayerPrefab;

    Player info;
    Player[] photonPlayers;

    public int playersInRoom;
    public int myNumberInRoom;



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
    }


    public override void OnEnable()
    {
        //subscribe to functions
        base.OnEnable();
        PhotonNetwork.AddCallbackTarget(this);
        SceneManager.sceneLoaded += OnSceneFinishedLoading;
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

    void StartGame()
    {
        Debug.Log("Loading Level");
        PhotonNetwork.LoadLevel(MultiplayerScene);
    }
    void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if (SceneManager.GetActiveScene() == scene && scene.name == "Fight Scene")
        {
            CreatePlayer();
        }
    }
    public string TruncateAtWord(string value, int length)
    {
        
        if (value.Length < IGN_limit.y || value.IndexOf(" ", IGN_limit.y) == -1)
            return value;

        return value.Substring(IGN_limit.x, value.IndexOf(" ", IGN_limit.y));
    }
    private void CreatePlayer()
    {
        // needs prefab name
        PhotonNetwork.Instantiate(PlayerPrefab.name, transform.position, Quaternion.identity, 0);
    }
}
