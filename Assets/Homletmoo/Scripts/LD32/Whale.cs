using UnityEngine;
using System.Collections;

public class Whale : MonoBehaviour
{
    public GameObject splashPrefab;
    public GameObject bigSplashPrefab;

	void Start()
    {
        GameObject splash = Instantiate(splashPrefab);
        GameObject bigSplash = Instantiate(bigSplashPrefab);
        splash.transform.position = transform.position;
        bigSplash.transform.position = transform.position;

        Rigidbody2D body = GetComponent<Rigidbody2D>();
        body.AddForce(new Vector2(0, 50000), ForceMode2D.Impulse);
	}

	void Update()
    {
        if (transform.position.y < 0)
        {
            Destroy(gameObject);
        }
	}
}
