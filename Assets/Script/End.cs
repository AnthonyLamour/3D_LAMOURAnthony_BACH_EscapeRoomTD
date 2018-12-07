using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour {

    public string NextScene;

	// Use this for initialization
	void OnTriggerEnter (Collider other) {
        if (other.tag == "Player" || other.tag=="PlayerPart" || other.tag == "PlayerPawn")
        {
            SceneManager.LoadScene(NextScene);
        }
	}
	
}
