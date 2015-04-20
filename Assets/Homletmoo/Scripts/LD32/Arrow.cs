using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour
{
    public float visibleDist;
    public float fadeDist;

	void Update()
    {
        GameObject explosion = GameObject.FindGameObjectWithTag("Explosion");
        if (explosion != null)
        {
            SpriteRenderer sprite = GetComponent<SpriteRenderer>();

            float dist = transform.position.x - explosion.transform.position.x;
            float alpha = (dist - visibleDist) / fadeDist;
            sprite.color = new Color(1, 1, 1, alpha);
        }
	}
}
