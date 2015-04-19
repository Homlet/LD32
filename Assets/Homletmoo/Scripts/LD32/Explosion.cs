using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour
{
    public GameObject[] whales;

    public float speed;

    void SpawnWhale()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) { return; }
        int index = Random.Range(0, whales.Length);

        GameObject whale = Instantiate(whales[index]);
        Vector2 position = new Vector2(player.transform.position.x + Random.Range(-10f, 10f), -10);
        whale.transform.position = position;
    }

	void Update()
    {
        transform.Translate(Time.deltaTime * speed, 0, 0);

        if (Random.Range(0f, 1f) > 0.995f)
        {
            SpawnWhale();
        }
	}
}
