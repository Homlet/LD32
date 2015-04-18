using UnityEngine;
using System.Collections;

public class ParallaxRotation : MonoBehaviour
{
    [Tooltip("Rotation factor in degrees per unit moved.")]
    public float factor;
	
	void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(0, factor * transform.position.x, 0);
	}
}
