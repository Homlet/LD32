using UnityEngine;
using System.Collections;

public class PlaneEngine : MonoBehaviour
{
    public GameObject smoke;
    public GameObject prop;

    // Power produced by engine in kilowatts.
    [Tooltip("Engine power in kW.")]
    public float enginePower;

    private float _thrust = 1;
    [HideInInspector]
    public float thrust {
        get { return _thrust; }
        set {
            _thrust = Mathf.Clamp(value, 0, 1);

            ParticleSystem emitter = smoke.GetComponent<ParticleSystem>();
            emitter.emissionRate = 200 * value;

            prop.GetComponent<Animator>().SetFloat("prop", value);
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
