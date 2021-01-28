using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixCamera : MonoBehaviour
{
    Canvas canvas = null;
    void Start()
    {
        canvas = GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canvas.worldCamera == null)
        {
            canvas.worldCamera = FindObjectOfType<Camera>();
        }
    }
}
