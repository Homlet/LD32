using UnityEngine;
using System.Collections;

public class Flash : MonoBehaviour
{
    public float visibleDistance;
    public float initialTime;

    float explosionTime = -1;

    void Update()
    {
        GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
        GameObject explosion = GameObject.FindGameObjectWithTag("Explosion");

        if (explosion != null)
        {
            if (explosionTime == -1)
            {
                explosionTime = Time.time;
            }

            float dist = camera.transform.position.x - explosion.transform.position.x;
            float distFactor = Mathf.Pow(1 - Mathf.Min(1, dist / visibleDistance), 2);
            float deltaTime = Time.time - explosionTime;
            float timeFactor = 1 - Mathf.Min(1, deltaTime / initialTime);

            SpriteRenderer sprite = GetComponent<SpriteRenderer>();
            sprite.color = new Color(1, 1, 1, timeFactor + distFactor);
        }
    }
}
