using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveButton : MonoBehaviour {

    public GameObject MurBouger;
    public Vector3 mouvement;
    public Vector3 PosFin;
    public int AV_AR;

    private bool Etat;

    void Start()
    {
        Etat = false;
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Etat = true;
        }
    }

    void Update()
    {
        if (Etat)
        {
            transform.Translate(mouvement);
            switch (AV_AR)
            {
                case 0:
                    if ((transform.position.x >= PosFin.x) || (transform.position.y >= PosFin.y) || (transform.position.z >= PosFin.z))
                    {
                        Destroy(gameObject);
                        Destroy(MurBouger.gameObject);
                    }
                    break;
                case 1:
                    if ((transform.position.x <= PosFin.x) || (transform.position.y <= PosFin.y) || (transform.position.z <= PosFin.z))
                    {
                        Destroy(gameObject);
                        Destroy(MurBouger.gameObject);
                    }
                    break;
                default:
                    break;
            }
           
        }
        

    }
}
