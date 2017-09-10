using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDector : MonoBehaviour {

    public GameMaster gameMaster;

    void OnTriggerEnter (Collider other)
    {
        gameMaster.hitCounter++;
    }

    void OnTriggerExit(Collider other)
    {
        if (gameMaster.hitCounter > 0)
        {
            gameMaster.hitCounter--;
        }
    }
}
