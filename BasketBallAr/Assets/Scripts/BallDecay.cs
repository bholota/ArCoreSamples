using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDecay : MonoBehaviour {

    public float timeUntilDestroyed = 10f; // 10 seconds

	// Update is called once per frame
	void Update () {
        Destroy(this.gameObject, timeUntilDestroyed);
    }
}
