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

    public static Vector3 Absolute(this Vector2 vector)
    {
        return new Vector3(Mathf.Abs(vector.x), Mathf.Abs(vector.y), 0);
    }
    public static Vector3 Absolute(this Vector3 vector)
    {
        return new Vector3(Mathf.Abs(vector.x), Mathf.Abs(vector.y), 0);
    }

    public static Vector3 Spherize(this Vector2 vector)
    {
        vector.Scale(vector.normalized.Absolute());
        return vector;
    }
    public static Vector3 Spherize(this Vector3 vector)
    {
        vector.Scale(vector.normalized.Absolute());
        return vector;
    }
}
