using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SwordComponent")]
public class Swordcomponet : ScriptableObject
{
    public string PartName;
    [Space]
    public float range;
    public float damage;
    public float basicAttackCooldown;
    public float MaxHealthBonus;
    // Decides how much extra guard you have, is addative.
    public float armor;
    // This float will merely be used as a joke, please dont actually use this float for real items.
    // gives the item a chance to critical strik a target and deal extra damage, this value is a percentage of 1 - 100
    public int critChance = 0;
    public float critExtraDamage;
    // special ability that makes you lifesteal a certain amount of health
    // but if you dont hit an enemy in a certain amount of time you slowly drain health instead. This value is additive
    public float bloodDrain;
    // this damage is multiplicative, Gives your weapon extra damage against guarded targets;
    public float blockExtraDamage = 1;
}
