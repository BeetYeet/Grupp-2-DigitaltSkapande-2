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
    public float weaponDamage;
    [HideInInspector]
    public PlayerController controller;
    Health health;
    PlayerInputActions input;

    /// <summary>
    /// the cooldown of the basic attack
    /// </summary>
    public float basicAttackCooldown;

    /// <summary>
    /// the time left untill the next attack is possible
    /// </summary>
    private float attackCooldown = 0;

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
        if (attackCooldown <= 0)
        {
            // attack ready
            PerformAttack();
            attackCooldown = basicAttackCooldown;
        }
    }

    private void OnEnable()
    {
        if (input != null)
            input.Enable();
    }
    private void OnDisable()
    {
        if (input != null)
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

        if (attackCooldown > 0)
        {
            attackCooldown -= Time.deltaTime;
            if (attackCooldown < 0)
                attackCooldown = 0;
        }
    }

    private void PerformAttack()
    {
        health.source.PlayOneShot(health.grunts[Random.Range(0, health.grunts.Length)]);
        controller.animationController.animator.SetTrigger("Attack");
        if (controller.movement.Target && Vector3.Distance(transform.position, controller.movement.Target.position) <= weaponRange)
            health.DoDamage(5, 1, controller.movement.Target.GetComponent<PhotonView>());
    }
}
