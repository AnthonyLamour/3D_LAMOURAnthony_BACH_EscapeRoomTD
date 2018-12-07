using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OuverturePorte : MonoBehaviour {

    public string key;

    private PlayerController PC;
    private GameObject PCObject;

    void OnTriggerEnter(Collider other)
    {
        int i=0;
        GameObject PCObject = GameObject.FindWithTag("Player");
        PC = PCObject.GetComponent<PlayerController>();
        if (other.tag == "PlayerPawn")
        {
            do
            {
                if (PC.ListeObj[i]==key)
                {
                    Destroy(gameObject);
                }
                i = i + 1;
            } while (i != PC.ListeObj.Length);
        }
    }

}
