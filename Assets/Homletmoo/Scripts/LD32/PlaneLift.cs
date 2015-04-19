using UnityEngine;
using System.Collections;

public class PlaneLift : MonoBehaviour
{
    [Tooltip("Area of the wing in square metres.")]
    public float wingArea;

    void FixedUpdate()
    {
        Rigidbody2D body = GetComponent<Rigidbody2D>();
        
        // Angle of attack.
        float aoa = transform.TransformDirection(1, 0, 0).TrueAngle(body.velocity);
        float scale = 0.5f * body.velocity.sqrMagnitude * wingArea;
        // Coefficient of lift approximation.
        float cl = 2 * Mathf.PI * aoa * Mathf.Deg2Rad;
        // Coefficient of drag approximation.
        float cd = 0.03f + cl * cl / (Mathf.PI * 6 * 0.9f);

        Vector2 dragDirection = -body.velocity.normalized;
        body.AddForce(cd * scale * dragDirection);
        Debug.DrawLine(body.worldCenterOfMass,
            body.worldCenterOfMass + cd * scale * dragDirection * 0.0005f);
        Debug.DrawLine(body.worldCenterOfMass,
            body.worldCenterOfMass + body.mass * body.gravityScale * -Vector2.up * 0.0005f);
        
        // After 65 degrees, lift falls off (stall).
        if (Mathf.Abs(aoa) < 65)
        {
            Vector2 liftDirection = body.velocity.normalized.Rotate(90);
            body.AddForce(cl * scale * liftDirection);
            Debug.DrawLine(body.worldCenterOfMass,
                body.worldCenterOfMass + cl * scale * liftDirection * 0.0005f);
        }

        // Major stall!
        if (Mathf.Abs(aoa) > 75)
        {
            print("STALL");
            body.AddForce(-body.velocity);
            GetComponent<PlaneEngine>().thrust -= 0.1f;
        }
    }
}
