using UnityEngine;
using System.Collections;

public class Whale : MonoBehaviour
{
	void Start()
    {
        Rigidbody2D body = GetComponent<Rigidbody2D>();
        body.AddForce(new Vector2(0, 500000), ForceMode2D.Impulse);
	}

	void Update()
    {
	    
	}
}
