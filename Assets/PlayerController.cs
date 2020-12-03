using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [HideInInspector]
    public PhotonView pView;
    [HideInInspector]
    public PlayerMovement movement;
    [HideInInspector]
    public PlayerAnimationController animationController;
    [HideInInspector]
    public PlayerCombat combat;
    [HideInInspector]
    public Health health;
    public bool offlineMode = false;

    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "Player Test Scene")
        {
            offlineMode = true;
            PhotonNetwork.OfflineMode = true;
        }
        else
        {
            offlineMode = false;
            PhotonNetwork.OfflineMode = false;
        }

        pView = GetComponent<PhotonView>();

        movement = GetComponent<PlayerMovement>();
        movement.controller = this;

        animationController = GetComponent<PlayerAnimationController>();
        animationController.controller = this;

        combat = GetComponent<PlayerCombat>();
        combat.controller = this;

        health = GetComponent<Health>();
        health.controller = this;

        if ((offlineMode && name == "Current Enemy Player") || (!pView.IsMine && !offlineMode))
        {
            Destroy(GetComponentInChildren<Camera>().gameObject);
        }

        if (pView.IsMine && name != "Current Enemy Player")
        {
            name = "Current Player";
            movement.viewBob = GetComponentInChildren<ViewBob>();
        }
        else
        {
            name = "Current Enemy Player";
        }
    }

    void Update()
    {

    }
}
