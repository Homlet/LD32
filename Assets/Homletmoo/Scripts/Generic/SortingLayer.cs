using UnityEngine;

public class SortingLayer : MonoBehaviour
{
    public string sortingLayer;

    void Awake()
    {
        GetComponent<Renderer>().sortingLayerName = sortingLayer;
    }
}
