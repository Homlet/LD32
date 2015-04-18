using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour
{
    bool expanding = true;

    void Awake()
    {
        transform.localScale = new Vector3(0, 0, 1);
    }

	void Update()
    {
        if (transform.localScale.x > 20) { expanding = false; }

        if (expanding)
        {
            transform.localScale += new Vector3(0.1f, 0.1f, 0);
            transform.Rotate(0, 0, 1);
        } else
        {
            transform.localScale -= new Vector3(0.01f, 0.01f, 0);

            SpriteRenderer sprite = GetComponent<SpriteRenderer>();
            sprite.color = new Color(
                sprite.color.r,
                sprite.color.g,
                sprite.color.b,
                sprite.color.a - 0.006f);
        }
	}
}
