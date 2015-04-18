using UnityEngine;
using System.Collections;

public class PlaneCollide : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        print("BAND");
        if (other.gameObject.tag == "Explosion")
        {
            Destroy(gameObject);
        }
    }
}
