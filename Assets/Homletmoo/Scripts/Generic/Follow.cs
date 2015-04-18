using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour
{
    public Transform parent;
    public Vector3 offset;

    void LateUpdate()
    {
        transform.position = parent.position + parent.TransformDirection(offset);
    }
}
