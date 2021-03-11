using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordEffect : MonoBehaviour
{
    public GameObject swordClashEffect;

    private void OnCollisionEnter(Collision collision)
    {
        // sword hit another sword (only hits its own layer)
        Debug.Log("Swords Clashed");
        if (swordClashEffect)
        {
            Instantiate(swordClashEffect, collision.GetContact(0).point, Quaternion.identity);
        }
    }
}
