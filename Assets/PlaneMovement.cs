using UnityEngine;
using System.Collections;

public class PlaneMovement : MonoBehaviour
{
    void Update()
    {
        transform.position += new Vector3(Time.deltaTime * 300, 0);
    }
}
