using UnityEngine;
using System.Collections;

public class PlaneHarpoon : MonoBehaviour
{
    public GameObject harpoon;

    public AudioSource harpoonAudio;

	void Update()
    {
        if (!Begin.playing) { return; }

        if (harpoon != null && !harpoon.activeInHierarchy)
        {
            if (Input.GetMouseButtonDown(0))
            {
                harpoonAudio.Play();

                Vector2 mousePos = (Vector2) Input.mousePosition;
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);

                harpoon.transform.position = transform.position;
                harpoon.SetActive(true);

                Vector2 direction = (mousePos - (Vector2) transform.position).normalized;

                Rigidbody2D harpoonBody = harpoon.GetComponent<Rigidbody2D>();
                harpoonBody.AddForce(0.7f * direction, ForceMode2D.Impulse);
            }
        }
	}
}
