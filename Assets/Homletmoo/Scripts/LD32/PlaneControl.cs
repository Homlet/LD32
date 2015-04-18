using UnityEngine;
using System.Collections;

public class PlaneControl : MonoBehaviour
{
    void Update()
    {
        PlaneEngine engine = GetComponent<PlaneEngine>();

        engine.thrust += Input.GetAxisRaw("Thrust") * 0.0025f;
    }

    void FixedUpdate()
    {
        Rigidbody2D body = GetComponent<Rigidbody2D>();

        body.AddTorque((Input.GetAxisRaw("Pitch") + 0.05f) * 3000f);
    }
}
