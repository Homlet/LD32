using UnityEngine;
using System.Collections;

public class Splash : MonoBehaviour
{
    public GameObject splashPrefab;
    public GameObject bigSplashPrefab;

    public AudioSource splashAudio;

    public float cooldown = 0;

    float lastSplashTime = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        float deltaTime = Time.time - lastSplashTime;

        if (deltaTime >= cooldown)
        {
            splashAudio.PlayOneShot(splashAudio.clip);

            Vector3 tempPosition = other.transform.position;
            tempPosition.y = 0.1f;

            GameObject splash = Instantiate(splashPrefab);
            GameObject bigSplash = Instantiate(bigSplashPrefab);
            splash.transform.position = tempPosition;
            bigSplash.transform.position = tempPosition;

            lastSplashTime = Time.time;
        }
    }
}
