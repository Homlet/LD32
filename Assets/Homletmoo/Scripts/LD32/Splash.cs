using UnityEngine;
using System.Collections;

public class Splash : MonoBehaviour
{
    public GameObject splashPrefab;
    public GameObject bigSplashPrefab;

    public float cooldown;

    float lastSplashTime = 0;
	
	void Update()
    {
        float deltaTime = Time.time - lastSplashTime;

        if (deltaTime >= cooldown && transform.position.y < 0)
        {
            GameObject splash = Instantiate(splashPrefab);
            GameObject bigSplash = Instantiate(bigSplashPrefab);
            splash.transform.position = transform.position;
            bigSplash.transform.position = transform.position;

            lastSplashTime = Time.time;
        }
	}
}
