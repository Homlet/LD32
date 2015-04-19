using UnityEngine;
using System.Collections;

public class DestroyOnFinish : MonoBehaviour
{
	void Update()
    {
        // Quick and simple.
        ParticleSystem emitter = GetComponent<ParticleSystem>();
        if (!emitter.isPlaying)
            Destroy(gameObject);
	}
}
