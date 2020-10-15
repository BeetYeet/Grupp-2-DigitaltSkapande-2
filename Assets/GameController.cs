using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public List<GameObject> players;

    void Awake()
    {
        if (instance != null)
            Debug.LogError("Multiple GameControllers!");
        instance = this;
    }

    private void Start()
    {
        
    }

    void Update()
    {
        
    }
}
