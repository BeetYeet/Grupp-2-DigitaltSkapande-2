using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerView : MonoBehaviour
{
    private Camera currentCamera;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!currentCamera)
        {
            currentCamera = FindObjectOfType<Camera>();
        }

        if (currentCamera)
        {
            transform.rotation = currentCamera.transform.rotation;
        }
    }
}
