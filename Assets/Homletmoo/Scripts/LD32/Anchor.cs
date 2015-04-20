using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Anchor : MonoBehaviour
{
    public GameObject to;

    void Start()
    {
        LineRenderer line = GetComponent<LineRenderer>();
        line.sortingLayerName = "Player";
        line.sortingOrder = -1;
    }

	void Update()
    {
        if (to != null)
        {
            LineRenderer line = GetComponent<LineRenderer>();
            line.SetPosition(0, to.transform.position);
            line.SetPosition(1, transform.position);
        }
	}
}
