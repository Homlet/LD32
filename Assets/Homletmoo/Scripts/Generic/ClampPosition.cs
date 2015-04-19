using UnityEngine;
using System.Collections;

public class ClampPosition : MonoBehaviour
{
    public bool clampX;
    public Vector2 xRange;

    public bool clampY;
    public Vector2 yRange;

    public bool clampZ;
    public Vector2 zRange;

    void LateUpdate()
    {
        Vector3 tempPosition = transform.position;
        if (clampX) { tempPosition.x = Mathf.Clamp(tempPosition.x, xRange.x, xRange.y); }
        if (clampY) { tempPosition.y = Mathf.Clamp(tempPosition.y, yRange.x, yRange.y); }
        if (clampZ) { tempPosition.z = Mathf.Clamp(tempPosition.z, zRange.x, zRange.y); }
        transform.position = tempPosition;
    }
}
