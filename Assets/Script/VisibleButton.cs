using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisibleButton : MonoBehaviour {

    private GameObject PCObject;

    void Start()
    {
        PCObject = GameObject.FindGameObjectWithTag("Masque");
    }

    // Update is called once per frame
    void Update()
    {
        if (PCObject.GetComponent<Image>().enabled == true)
        {
            this.GetComponent<MeshRenderer>().enabled = true;
        }
        else if (PCObject.GetComponent<Image>().enabled == false)
        {
            this.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
