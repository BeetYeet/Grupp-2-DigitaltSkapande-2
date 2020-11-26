using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    public static Vector3 ToXZ(this Vector2 vector)
    {
        return new Vector3(vector.x, 0, vector.y);
    }
    public static Vector3 ToXY(this Vector2 vector)
    {
        return new Vector3(vector.x, vector.y, 0);
    }
}
