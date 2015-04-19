using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour
{
    public GameObject explosionPrefab;

    void Start()
    {
        Rigidbody2D body = GetComponent<Rigidbody2D>();
        body.AddTorque(-3, ForceMode2D.Impulse);
    }
    
    void FixedUpdate()
    {
        if (transform.position.y <= 0)
        {
            Detonate();
        }
    }

    void Detonate()
    {
        Instantiate(explosionPrefab);

        Destroy(gameObject);
    }
}
