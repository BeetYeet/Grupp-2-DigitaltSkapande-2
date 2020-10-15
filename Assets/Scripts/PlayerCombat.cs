﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Realtime;
using Photon.Pun;

public class PlayerCombat : MonoBehaviour
{
    public float maxHealth, health;
    PlayerController playerController;
    public HitBox hitBox;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        playerController = GetComponent<PlayerController>();
    }

    public void DoDamgeToPlayer(float dmg, PhotonView player)
    {
        player.RPC("DoDamage", RpcTarget.All, dmg);
    }
    [PunRPC]
    public void DoDamage(float dmg)
    {
        health = Mathf.Max(0, health - dmg);
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
            Debug.LogError("YOUR DEAD!");
        var mouse = Mouse.current;
        if (mouse == null)
            return;
        if (mouse.leftButton.wasPressedThisFrame)
        {
            Debug.LogWarning("clicked");
            DoDamgeToPlayer(10, playerController.movement.target.GetComponent<PhotonView>());
        }
    }
}
