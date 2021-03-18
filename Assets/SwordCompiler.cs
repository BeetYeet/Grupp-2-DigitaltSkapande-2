using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCompiler : MonoBehaviour
{
    public SwordCompiler[] blades, guards, handles;
    public int bladeId, guardId, handleId;
    [Space]
    public float damage, range, timeBetweenAttacks, health;

    private void Update()
    {
        damage = blades[bladeId].damage + guards[guardId].damage + handles[handleId].damage;
        range = blades[bladeId].range + guards[guardId].range + handles[handleId].range;
        timeBetweenAttacks = blades[bladeId].ba + guards[guardId].damage + handles[handleId].damage;
        damage = blades[bladeId].damage + guards[guardId].damage + handles[handleId].damage;
    }
}
