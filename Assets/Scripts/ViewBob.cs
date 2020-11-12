using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewBob : MonoBehaviour
{
    [HideInInspector]
    public float followScale = 0.1f;
    [HideInInspector]
    public Vector2 bobScale = new Vector2(1, 1);
    [HideInInspector]
    public float degreesPerSecond = 90;
    [HideInInspector]
    public float angleCutoff = 90;

    [HideInInspector]
    public bool moving = false;
    [HideInInspector]
    public float moveVectorX = 0f;

    float angle = 0;
    bool left = true;
    void Start()
    {

    }

    void LateUpdate()
    {
        if (moving)
        {
            bool effectiveLeft = left ^ moveVectorX < 0;
            if (effectiveLeft)
            {
                angle += Time.deltaTime * degreesPerSecond;
                if (angle > angleCutoff)
                {
                    left = !left;
                }
            }
            else
            {
                angle -= Time.deltaTime * degreesPerSecond;
                if (angle < -angleCutoff)
                {
                    left = !left;
                }
            }
        }
        else
        {
            angle *= .9f;
        }

        Vector2 xy = new Vector2(Mathf.Cos((angle + 270) * Mathf.Deg2Rad), Mathf.Sin((angle + 270) * Mathf.Deg2Rad));
        Vector3 target = transform.rotation * xy * bobScale + bobScale * Vector2.up * .7f;
        if (!moving)
            target = Vector3.zero;
        transform.localPosition = Vector3.Lerp(transform.localPosition, target, followScale);
    }
}
