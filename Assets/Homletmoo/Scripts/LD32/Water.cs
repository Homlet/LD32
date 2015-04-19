using UnityEngine;
using System.Collections;

public class Water : MonoBehaviour
{
    public float riseTime;
    public float fallTime;

    float explosionTime = -1;

    void Update()
    {
        GameObject explosion = GameObject.FindGameObjectWithTag("Explosion");

        if (explosion != null)
        {
            if (explosionTime == -1)
            {
                explosionTime = Time.time;
            }

            float deltaTime = Time.time - explosionTime;
            Vector3 tempPosition = transform.position;

            if (deltaTime < riseTime)
            {
                tempPosition.y = 30 * Mathf.Sqrt(deltaTime / riseTime);
            } else if (deltaTime < riseTime + fallTime)
            {
                tempPosition.y = 30 * (1 - Mathf.Pow(deltaTime / (riseTime + fallTime), 4));
            }

            transform.position = tempPosition;
        }
    }
}
