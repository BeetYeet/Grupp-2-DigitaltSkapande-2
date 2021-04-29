using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public List<GameObject> players;

    void Awake()
    {
        if (instance != null)
            Debug.LogError("Multiple GameControllers!");
        instance = this;
    }

    public static void RefreshPlayers()
    {
        instance.players = GameObject.FindGameObjectsWithTag("Player").ToList();
    }

    private void Start()
    {

    }

    void Update()
    {

    }
}
