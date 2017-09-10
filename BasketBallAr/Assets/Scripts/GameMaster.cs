using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

    public Text pointsText;
    public int hitCounter = 0;
    public int points = 0;

	// Update is called once per frame
	void Update () {
		if (hitCounter == 2)
        {
            points++;
            hitCounter = 0;
            pointsText.text = "Points: " + points;
        }
	}
}
