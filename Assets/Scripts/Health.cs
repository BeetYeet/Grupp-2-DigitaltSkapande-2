using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Realtime;
using Photon.Pun.UtilityScripts;
using Photon.Pun;
using Photon;

public class Health : MonoBehaviour
{
    [Header("Healthbar")]
    public float currentHealth;
    public float startHealth = 10;

    public float regeneratableHealth;
    public float regenHealthTickDown = 0.5f;
    public float regeneratableHealthMultiplier = 0.15f;

    [Header("Blocking")]
    public float timeUntilRegenStart;
    float timeUntilBlockRegen;
    public float blockRegenSpeed = 0.5f;
    public float blockDamageUntilStagger = 10;
    public float blockDamage;
    public bool isBlocking;

    [Header("Parry")]
    public float parryDamageMultiplier = 0.1f;
    public float parryTimer;
    public float parryThreshHold = 0.2f;

    [Header("Stagger")]
    public float startStaggerTime;
    float staggerTime;
    public bool canMove = true;
    

    

    private void Start()
    {
        currentHealth = startHealth;
    }
    public void SyncHealth(PhotonView photonView)
    {

        photonView.RPC("RegenerateHealth", RpcTarget.All);
    }
    void FixedUpdate()
    {
        
        currentHealth = Mathf.Round(currentHealth * 100) / 100;

       

        if (isBlocking == true)
        {
            parryTimer += (float)PhotonNetwork.Time;
        }
        else
        {
            parryTimer = 0;
        }

        // starts the regeneration time
        if (timeUntilBlockRegen > 0)
            timeUntilBlockRegen -= (float)PhotonNetwork.Time;
        else
            timeUntilBlockRegen = 0;

        //Regenerates Block
        if (blockDamage > 0 && timeUntilBlockRegen <= 0)
            blockDamage -= blockRegenSpeed * (float)PhotonNetwork.Time;
        else if (blockDamage < 0)
            blockDamage = 0;

        // Staggers the player
        if (blockDamage >= blockDamageUntilStagger)
        {
            Stagger();
        }
        // Controlls the time
        if (staggerTime > 0)
        {
            staggerTime -= (float)PhotonNetwork.Time;
        }
        else
        {
            staggerTime = 0;
        }

        // Regenerates Health
        if (regeneratableHealth > currentHealth)
            regeneratableHealth -= regenHealthTickDown * (float)PhotonNetwork.Time;
        else
            regeneratableHealth = currentHealth;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Block()
    {
        isBlocking = true;
    }

    public void DoDamage(float dmg, float blockMulitpier, PhotonView apponent)
    {
        apponent.RPC("TakeDamage", RpcTarget.All, dmg, blockMulitpier);
    }
    private void Stagger()
    {
        isBlocking = false;
        staggerTime = startStaggerTime;
        blockDamage = 0;
    }

    private void Die()
    {
        Debug.Log("this character is dead");
    }
    [PunRPC]
    void RegenerateHealth()
    {
        if (currentHealth < regeneratableHealth)
        {
            float missingHealth = regeneratableHealth - currentHealth;
            currentHealth += regeneratableHealthMultiplier * missingHealth;
        }
    }
    [PunRPC]
    void TakeDamage(float damage, float blockDamageMultiplier = 1)
    {
        if (isBlocking == false)
        {
            currentHealth -= damage;
        }
        else
        {
            if (parryTimer < parryThreshHold)
                TakeBlockDamage(damage * blockDamageMultiplier);
            else
                TakeBlockDamage(damage * parryDamageMultiplier);
        }
    }
    public void TakeBlockDamage(float blockDamage)
    {
        timeUntilBlockRegen = timeUntilRegenStart;
        if (this.blockDamage <= blockDamageUntilStagger)
        {
            this.blockDamage += blockDamage;
        }
    }
}
