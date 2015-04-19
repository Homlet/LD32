using UnityEngine;
using System.Collections;

public class PlaneDeath : MonoBehaviour
{
    void Die(string reason)
    {
        print(reason);
        Destroy(gameObject);
    }

    void Update()
    {
        GameObject explosion = GameObject.FindGameObjectWithTag("Explosion");

        if (explosion != null)
        {
            if (transform.position.x < explosion.transform.position.x)
                Die("Burnt to a Crisp");
        }

        if (transform.position.y < 0)
            Die("Splashed Down");
    }
}
