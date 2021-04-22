using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLighting : MonoBehaviour
{
    [SerializeField] Vector3 spawnBounds;
    [SerializeField] GameObject lighting_bolt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, spawnBounds);
    }

    private void InitializeLighting(GameObject lighting)
    {
        GameObject _lighting = lighting;
    }
}
