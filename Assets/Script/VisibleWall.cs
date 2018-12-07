using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisibleWall : MonoBehaviour {

	private GameObject PCObject;

	
	// Use this for initialization
	void Start () {
        PCObject = GameObject.FindGameObjectWithTag("Masque");
    }
	
	// Update is called once per frame
	void Update () {
		if(PCObject.GetComponent<Image>().enabled == true)
        {
            this.GetComponent<MeshRenderer>().enabled = false;
		}else if(PCObject.GetComponent<Image>().enabled == false)
        {
			this.GetComponent<MeshRenderer>().enabled=true;
		}
	}
}
