using UnityEngine;
using System.Collections;

public class PlaneControl : MonoBehaviour
{
    void Update()
    {
        PlaneEngine engine = GetComponent<PlaneEngine>();

        engine.thrust += Input.GetAxisRaw("Thrust") * 0.0025f;
        print(engine.thrust);
    }
}
