using UnityEngine;
using System.Collections;

public class FaceVelocity : MonoBehaviour
{
    public GameObject relative;

	void FixedUpdate()
    {
        Rigidbody2D body = GetComponent<Rigidbody2D>();
        Vector2 velocity = body.velocity;

        if (relative != null)
        {
            Rigidbody2D parent = relative.GetComponent<Rigidbody2D>();
            velocity -= parent.velocity;
        }

        if (velocity.magnitude > 0)
        {
            float angle = Mathf.Atan2(velocity.y,velocity.x);
            transform.rotation = Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg);
        }
	}
}
