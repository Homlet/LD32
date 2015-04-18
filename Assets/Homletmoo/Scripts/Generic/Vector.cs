using UnityEngine;
using System.Collections;

public static class Vector
{
    public static float TrueAngle(this Vector2 from, Vector2 to)
    {
        float angle = Vector2.Angle(from, to);
        Vector3 cross = Vector3.Cross(from, to);

        if (cross.z > 0) { angle = -angle; }

        return angle;
    }

    public static float TrueAngle(this Vector3 from, Vector2 to)
    {
        return ((Vector2) from).TrueAngle(to);
    }

    public static float TrueAngle(this Vector2 from, Vector3 to)
    {
        return from.TrueAngle((Vector2) to);
    }

    public static float TrueAngle(this Vector3 from, Vector3 to)
    {
        return from.TrueAngle((Vector2) to);
    }

    public static Vector2 Rotate(this Vector2 v, float degrees)
    {
        float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
        float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);

        float tx = v.x;
        float ty = v.y;
        v.x = (cos * tx) - (sin * ty);
        v.y = (sin * tx) + (cos * ty);

        return v;
    }

    public static Vector2 Rotate(this Vector3 v, float degrees)
    {
        return ((Vector2) v).Rotate(degrees);
    }
}
