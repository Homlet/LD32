using UnityEngine;
using System.Collections;


public class Advance : MonoBehaviour
{
    int loadedLevel;
    int levelCount;

    public void Awake()
    {
        loadedLevel = Application.loadedLevel;
        levelCount = Application.levelCount;
    }

    public void AdvanceScene()
    {
        Application.LoadLevel((loadedLevel + 1) % levelCount);
    }
}
