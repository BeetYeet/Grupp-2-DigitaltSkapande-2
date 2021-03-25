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
}
