using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public PhotonView pView;

    public PlayerMovement movement;
    public PlayerAnimationController animationController;

    private void Awake()
    {
        movement = GetComponent<PlayerMovement>();
        movement.controller = this;

        animationController = GetComponent<PlayerAnimationController>();
        animationController.controller = this;

        pView = GetComponent<PhotonView>();
        if (!pView.IsMine)
        {
            Destroy(GetComponentInChildren<Camera>());
        }
    }

    void Update()
    {

    }
}
