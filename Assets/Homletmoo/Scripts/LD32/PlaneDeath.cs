using UnityEngine;
using System.Collections;

public class PlaneDeath : MonoBehaviour
{
    void Die(string reason)
    {
        Globals.deathReason = reason;

        Destroy(gameObject);

        Application.LoadLevel(2);
    }

    void Update()
    {
        GameObject explosion = GameObject.FindGameObjectWithTag("Explosion");

        if (explosion != null)
        {
            if (transform.position.x < explosion.transform.position.x)
                Die("Were Burnt to a Crisp");
        }

        if (transform.position.y < 0)
            Die("Splashed Down");
    }
}
