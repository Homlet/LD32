using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[ExecuteInEditMode]
public class DeathText : MonoBehaviour
{
	void Start()
    {
        GetComponent<Text>().text = "Commiserations.\n" +
            "You committed whaleslaughter\n" + Globals.score.ToString()
            + " times\nbefore you " + Globals.deathReason + ".";
	}
}
