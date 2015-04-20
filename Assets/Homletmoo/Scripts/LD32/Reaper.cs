using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Reaper : MonoBehaviour
{
    int _captured = 0;
    public int captured {
        get { return _captured; }
        set {
            _captured = value;

            Globals.score = captured;

            GameObject counter = GameObject.FindGameObjectWithTag("Counter");
            counter.GetComponent<Text>().text = "Whales: " + captured.ToString();
        }
    }
}
