using UnityEngine;
using System.Collections;

public class Whale : MonoBehaviour
{
    public Vector2 riseVelocity;

    bool rising = true;
    bool captured = false;

    void Rise()
    {
        transform.position += (Vector3) (Time.deltaTime * riseVelocity);

        if (transform.position.y > 45)
        {
            rising = false;

            transform.localScale = new Vector3(1, 1, 1);
            transform.position = transform.position + new Vector3(40, 0, 0);

            SpriteRenderer sprite = GetComponent<SpriteRenderer>();
            sprite.color = new Color(1, 1, 1, 1);

            Rigidbody2D body = GetComponent<Rigidbody2D>();
            body.isKinematic = false;
            foreach (Collider2D collider in GetComponents<Collider2D>())
            {
                collider.enabled = true;
            }
        }
    }

    public void Capture(Transform other)
    {
        captured = true;

        gameObject.AddComponent<Follow>();
        GetComponent<Follow>().parent = other;

        transform.localScale = new Vector3(0.75f, 0.75f, 1);

        GetComponent<Rigidbody2D>().isKinematic = true;
        GetComponent<Collider2D>().isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!captured)
            return;

        if (other.gameObject.tag == "Reaper")
        {
            other.gameObject.GetComponent<Reaper>().captured++;
            Destroy(gameObject);
        }
    }

    void Fall()
    {
        if (transform.position.y < 0)
        {
            Destroy(gameObject);
        }
    }

	void Start()
    {
        transform.localScale = new Vector3(1.5f, 1.5f, 1);

        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        sprite.color = new Color(1, 1, 1, 0.5f);

        Rigidbody2D body = GetComponent<Rigidbody2D>();
        body.isKinematic = true;
        foreach (Collider2D collider in GetComponents<Collider2D>())
        {
            collider.enabled = false;
        }
	}

	void Update()
    {
        if (rising)
            Rise();
        else
            Fall();
	}
}
