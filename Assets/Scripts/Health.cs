using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
    void Update()
    {
        var gamePad = Keyboard.current;
        if (gamePad.spaceKey.wasPressedThisFrame)
            isBlocking = true;
        if (gamePad.sKey.wasPressedThisFrame)
            RegenerateHealth();

        if (gamePad.aKey.wasPressedThisFrame)
            TakeDamage(1);

        if (isBlocking == true)
        {
            parryTimer += Time.deltaTime;
        }
        else
        {
            parryTimer = 0;
        }

        // starts the regeneration time
        if (timeUntilBlockRegen > 0)
            timeUntilBlockRegen -= Time.deltaTime;
        else
            timeUntilBlockRegen = 0;

        //Regenerates Block
        if (blockDamage > 0 && timeUntilBlockRegen <= 0)
            blockDamage -= blockRegenSpeed * Time.deltaTime;
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
            staggerTime -= Time.deltaTime;
        }
        else
        {
            staggerTime = 0;
        }

        // Regenerates Health
        if (regeneratableHealth > currentHealth)
            regeneratableHealth -= regenHealthTickDown * Time.deltaTime;
        else
            regeneratableHealth = currentHealth;

        if (currentHealth <= 0)
        {
            Die();
        }
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
    public void RegenerateHealth()
    {
        if (currentHealth < regeneratableHealth)
        {
            float missingHealth = regeneratableHealth - currentHealth;
            currentHealth += regeneratableHealthMultiplier * missingHealth;
        }
    }

    public void TakeDamage(float damage, float blockDamageMultiplier = 1)
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
