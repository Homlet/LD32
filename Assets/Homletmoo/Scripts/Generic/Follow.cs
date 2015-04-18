using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour
{
    public Transform parent;
    public Vector3 offset;

    public float xFactor = 1;
    public float yFactor = 1;
    public float zFactor = 1;

    void LateUpdate()
    {
        Vector3 tempPosition = parent.position +
            parent.TransformDirection(offset);
        tempPosition.x *= xFactor;
        tempPosition.y *= yFactor;
        tempPosition.z *= zFactor;
        transform.position = tempPosition;
    }
}
