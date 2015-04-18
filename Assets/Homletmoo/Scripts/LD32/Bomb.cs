using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour
{
    void FixedUpdate()
    {
        Rigidbody2D body = GetComponent<Rigidbody2D>();
        print(body.position.y);
        if (transform.position.y <= -60)
        {
            Detonate();
        }
    }

    void Detonate()
    {
        print("BANG");
    }
}
