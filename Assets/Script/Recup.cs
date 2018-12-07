using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recup : MonoBehaviour {

    // Use this for initialization
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "PlayerPart" || other.tag == "PlayerPawn")
        {
            Destroy(gameObject);
        }
    }
}
