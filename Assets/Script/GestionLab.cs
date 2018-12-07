using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionLab : MonoBehaviour {

    private PlayerController PC;
    private GameObject PCObject;

    void Start()
    {
        GameObject PCObject = GameObject.FindWithTag("Player");
        PC = PCObject.GetComponent<PlayerController>();

    }
	
	// Update is called once per frame
	void Update () {
        if (PC.UseMasque)
        {
            if (this.GetComponent<MeshRenderer>().enabled == false)
            {
                this.GetComponent<MeshRenderer>().enabled = true;
            }
            else
            {
                this.GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }
}
