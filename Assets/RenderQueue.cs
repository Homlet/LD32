using UnityEngine;
using System.Collections;

public class RenderQueue : MonoBehaviour
{
	void Awake()
    {
        GetComponent<MeshRenderer>().material.renderQueue = -1000;
    }
}
