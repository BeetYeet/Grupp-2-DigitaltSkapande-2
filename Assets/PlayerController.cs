using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    PhotonView view;

    public PlayerMovement movement;

    private void Awake()
    {
        movement = GetComponent<PlayerMovement>();
        view = GetComponent<PhotonView>();
    }

    void Start()
    {
        if (!view.IsMine)
        {
            Destroy(transform.GetChild(0).GetComponent<Camera>());
        }
    }

    void Update()
    {

    }
}
