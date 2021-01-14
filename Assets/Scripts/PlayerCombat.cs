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
    [HideInInspector]
    public PlayerController controller;
    Health health;
    PlayerInputActions input;
    bool attackedThisFrame = false;

    // Start is called before the first frame update
    void Start()
    {
        health = controller.health;
        input = new PlayerInputActions();
        input.Enable();
        input.MainActionMap.Attack.performed += Attack_performed;
    }

    private void Attack_performed(InputAction.CallbackContext obj)
    {
        attackedThisFrame = true;
    }

    private void OnEnable()
    {
        input.Enable();
    }
    private void OnDisable()
    {
        input.Disable();
    }

    private void FixedUpdate()
    {
        if (!controller.offlineMode)
            health.SyncHealth(controller.pView);
    }
    // Update is called once per frame
    void Update()
    {
        if (controller.offlineMode && name == "Current Enemy Player")
            return;
        Mouse mouse = Mouse.current;
        if (mouse == null)
            return;
        if (mouse.rightButton.wasReleasedThisFrame)
            health.DoDamage(3, 1, controller.pView);
        if (mouse.leftButton.wasPressedThisFrame || attackedThisFrame)
        {
            attackedThisFrame = false;
            controller.animationController.animator.SetTrigger("Attack");
            Debug.Log("clicked");
            if (controller.movement.target && Vector3.Distance(transform.position, controller.movement.target.position) <= weaponRange)
                health.DoDamage(5, 1, controller.movement.target.GetComponent<PhotonView>());
        }
    }
}
