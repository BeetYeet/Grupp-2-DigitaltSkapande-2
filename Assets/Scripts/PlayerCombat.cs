using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Realtime;
using Photon.Pun;
using UnityEditor;

public class PlayerCombat : MonoBehaviour
{
    public float weaponRange;
    PlayerController playerController;
    Health health;

    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>();
        playerController = GetComponent<PlayerController>();
    }

    private void FixedUpdate()
    {
        health.SyncHealth(playerController.pView);
    }
    // Update is called once per frame
    void Update()
    {

        var mouse = Mouse.current;
        if (mouse == null)
            return;
        if (mouse.rightButton.wasReleasedThisFrame)
            health.DoDamage(3, 1, playerController.pView);
        if (mouse.leftButton.wasPressedThisFrame)
        {
            playerController.animationController.animator.SetTrigger("Attack");
            Debug.LogWarning("clicked");
            if (playerController.movement.target && Vector3.Distance(transform.position, playerController.movement.target.position) <= weaponRange)
                health.DoDamage(5, 1, playerController.movement.target.GetComponent<PhotonView>());
        }
    }
}
