using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour
{
    public GameObject explosionPrefab;
    public AudioSource explosionAudio;
    
    void FixedUpdate()
    {
        if (transform.position.y <= 0)
        {
            Detonate();
        }
    }

    void Detonate()
    {
        GameObject explosion = Instantiate(explosionPrefab);
        explosion.transform.position = new Vector3(transform.position.x, 0, 0);

        explosionAudio.Play();

        Destroy(gameObject);
    }
}
