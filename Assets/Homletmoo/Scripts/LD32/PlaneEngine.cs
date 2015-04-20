using UnityEngine;
using System.Collections;

public class PlaneEngine : MonoBehaviour
{
    public GameObject smoke;
    public GameObject prop;

    public AudioSource engineAudio;
    public AudioSource stallAudio;

    // Power produced by engine in kilowatts.
    [Tooltip("Engine power in kW.")]
    public float enginePower;

    bool stalled = false;
    float _thrust = 1;
    [HideInInspector]
    public float thrust {
        get { return _thrust; }
        set {
            _thrust = Mathf.Clamp(value, 0, 1);

            ParticleSystem emitter = smoke.GetComponent<ParticleSystem>();
            emitter.emissionRate = 5 + 200 * thrust * thrust;

            prop.GetComponent<Animator>().SetFloat("prop", thrust);

            if (thrust > 0.5f || !Begin.playing)
            {
                if (!engineAudio.isPlaying) { engineAudio.Play(); }

                stalled = false;
            } else
            {
                engineAudio.Stop();
                if (!stalled) { stallAudio.Play(); }

                stalled = true;
            }
        }
    }

    void FixedUpdate()
    {
        Rigidbody2D body = GetComponent<Rigidbody2D>();

        if (body.velocity.magnitude > 0)
        {
            float force = thrust * 1000 * enginePower / body.velocity.magnitude;
            Vector2 direction = transform.TransformDirection(1, 0, 0);
            Vector2 position = body.worldCenterOfMass +
                (Vector2) transform.TransformVector(0, -0.001f, 0);
            body.AddForceAtPosition(force * direction, position);
        }
    }
}
