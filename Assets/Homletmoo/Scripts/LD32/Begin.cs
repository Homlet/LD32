using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Begin : MonoBehaviour
{
    public GameObject plane;
    public GameObject bomb;
    public GameObject music;

    public static bool playing = false;

    void Play()
    {
        playing = true;

        plane.GetComponent<Rigidbody2D>().isKinematic = false;
        bomb.GetComponent<Rigidbody2D>().isKinematic = false;

        music.GetComponent<Music>().Play();

        GameObject counter = GameObject.FindGameObjectWithTag("Counter");
        counter.GetComponent<Text>().text = "Whales: 0";

        GameObject logo = GameObject.FindGameObjectWithTag("Logo");
        logo.GetComponent<Follow>().enabled = false;
    }
    
	void Start()
    {
        Globals.score = 0;

        playing = false;

        plane.GetComponent<Rigidbody2D>().isKinematic = true;
        bomb.GetComponent<Rigidbody2D>().isKinematic = true;
	}
	
	void Update()
    {
        if (!playing)
        {
            plane.transform.Translate(0.025f, 0, 0);

            if (Input.GetAxisRaw("Begin") == 1)
            {
                Play();
            }
        } else
        {
            if (bomb != null)
            {
                bomb.GetComponent<Rigidbody2D>().AddTorque(-0.5f);
            }
        }
	}
}
