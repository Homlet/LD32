using UnityEngine;
using System.Collections;

public class Flash : MonoBehaviour
{
    public float visibleDistance;
    public float initialTime;

    float explosionTime = -1;

    void Update()
    {
        GameObject plane = GameObject.FindGameObjectWithTag("Player");
        GameObject explosion = GameObject.FindGameObjectWithTag("Explosion");

        if (plane != null && explosion != null)
        {
            if (explosionTime == -1)
            {
                explosionTime = Time.time;
            }

            float dist = plane.transform.position.x - explosion.transform.position.x;
            float distFactor = Mathf.Pow(1 - Mathf.Min(1, dist / visibleDistance), 2);
            float deltaTime = Time.time - explosionTime;
            float timeFactor = 1 - Mathf.Min(1, deltaTime / initialTime);

            print(timeFactor + " : " + distFactor);

            SpriteRenderer sprite = GetComponent<SpriteRenderer>();
            sprite.color = new Color(1, 1, 1, timeFactor + distFactor);
        }
    }
}
