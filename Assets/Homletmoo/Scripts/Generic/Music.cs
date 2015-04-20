using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour
{
    public AudioClip intro;
    public AudioClip loop;

    [Range(0, 1)]
    public float volume;

    [HideInInspector]
    public bool playing = false;

    public void Play()
    {
        playing = true;

        for (int i = 0; i < 2; i++)
            gameObject.AddComponent<AudioSource>();

        AudioSource[] source = GetComponents<AudioSource>();
        source[0].clip = intro;
        source[0].loop = false;
        source[0].volume = volume;
        source[1].clip = loop;
        source[1].loop = true;
        source[1].volume = volume;

        source[0].Play();
        Invoke("Loop", intro.length - 0.2f);
    }

    void Loop()
    {
        AudioSource[] source = GetComponents<AudioSource>();
        source[1].Play();
    }
}
