using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public PhotonView view;

    public PlayerMovement movement;

    private void Awake()
    {
        movement = GetComponent<PlayerMovement>();
        view = GetComponent<PhotonView>();
        if (!view.IsMine)
        {
            Destroy(transform.GetChild(0).GetComponent<Camera>());
        }
    }

    void Update()
    {

    }
}
