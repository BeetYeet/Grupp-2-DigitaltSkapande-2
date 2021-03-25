using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCompiler : MonoBehaviour
{
    public Swordcomponet[] blades, guards, handles;
    public int bladeId, guardId, handleId;
    [Space]
    public float damage, range, timeBetweenAttacks, health;

    private void Update()
    {
           
        
    }

    public void ReCalculate()
    {
        Debug.Log("Eqiuped blade " + blades[bladeId] + ", eqiuped guard " + guards[guardId] + ", eqiuped handle " + handles[handleId] + ".");
        damage = blades[bladeId].damage + guards[guardId].damage + handles[handleId].damage;
        range = blades[bladeId].range + guards[guardId].range + handles[handleId].range;
        timeBetweenAttacks = blades[bladeId].basicAttackCooldown + guards[guardId].basicAttackCooldown + handles[handleId].basicAttackCooldown;
        health = blades[bladeId].damage + guards[guardId].damage + handles[handleId].damage;
    }
}
