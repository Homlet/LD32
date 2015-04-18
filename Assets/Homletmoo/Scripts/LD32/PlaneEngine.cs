using UnityEngine;
using System.Collections;

public class PlaneEngine : MonoBehaviour
{
    // Power produced by engine in kilowatts.
    [Tooltip("Engine power in kW.")]
    public float enginePower;

    private float _thrust = 1;
    [HideInInspector]
    public float thrust {
        get { return _thrust; }
        set { _thrust = Mathf.Clamp(value, 0, 1); }
    }

    public GameObject smoke;

    void Update()
    {
        ParticleSystem emitter = smoke.GetComponent<ParticleSystem>();
        emitter.emissionRate = 200 * thrust;
    }

    void FixedUpdate()
    {
        Rigidbody2D body = GetComponent<Rigidbody2D>();

        if (body.velocity.magnitude > 0)
        {
            float force = thrust * 1000 * enginePower / body.velocity.magnitude;
            Vector2 direction = transform.TransformDirection(1, 0, 0);
            body.AddForce(force * direction);
        }
    }
}
