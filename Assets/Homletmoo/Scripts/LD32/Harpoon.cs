using UnityEngine;
using System.Collections;

public class Harpoon : MonoBehaviour
{
    public float cooldown;

    public AudioSource hitAudio;

    float launchTime = 0;

    void OnEnable()
    {
        launchTime = Time.time;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        float deltaTime = Time.time - launchTime;

        if (deltaTime > cooldown && other.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
        }

        if (other.gameObject.tag == "Whale")
        {
            hitAudio.Play();

            other.GetComponent<Whale>().Capture(transform);
        }
    }
}
