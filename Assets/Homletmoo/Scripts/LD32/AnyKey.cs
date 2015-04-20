using UnityEngine;
using System.Collections;

public class AnyKey : MonoBehaviour
{
    public float preDelay;

    float startTime = 0;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        float deltaTime = Time.time - startTime;

        if (deltaTime > preDelay && Input.anyKeyDown)
        {
            Application.LoadLevel(1);
        }
    }
}
