using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public GameObject Masque;
    public bool UseMasque;
    public Text InvText;
    public Text TimerText;
    public GameObject MaCam;
    public GameObject Walk;

    public string[] ListeObj;
    private float timer;
    private float min;
    private float sec;
    private int debutTimer;
    private string[] TempTab;
    float speed = 10.0f;
    float maxVelocityChange = 10.0f;
    private bool isPlaying;

    void Start()
    {
        //this.GetComponent<Rigidbody>().inertiaTensor =new Vector3 (0.0f,0.0f,0.0f);
        UseMasque = false;
        ListeObj = new string[1];
        ListeObj[0] = "NULL";
        TempTab = new string[1];
        TempTab[0] = "NULL";
        sec = 1;
        isPlaying = false;

    }

    // Update is called once per frame
    void Update()
    {

        sec = Time.time;
        sec = (15.0f * 60) - sec;
        min = Mathf.Floor(sec / 60);
        sec = sec % 60;

        if ((Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) && isPlaying == false)
        {
            Walk.GetComponent<AudioSource>().Play();
            isPlaying = true;
        }
        else if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            Walk.GetComponent<AudioSource>().Stop();
            isPlaying = false;
        }

        if (sec < 1)
        {
            TimerText.text = string.Concat("Time :", min.ToString("#00"), ":00", sec.ToString("#.00"));
        }
        else if (sec < 10)
        {
            TimerText.text = string.Concat("Time :", min.ToString("#00"), ":0", sec.ToString("#.00"));
        }
        else
        {
            TimerText.text = string.Concat("Time :", min.ToString("#00"), ":", sec.ToString("#.00"));
        }
        if(min<=0 && sec <= 0)
        {
            Application.Quit();
        }

        if (Input.GetKeyDown("space") && Masque.GetComponent<Image>().enabled == false)
        {
            Masque.GetComponent<Image>().enabled = true;
            UseMasque = true;
        }
        else if (Input.GetKeyDown("space") && Masque.GetComponent<Image>().enabled == true)
        {
            Masque.GetComponent<Image>().enabled = false;
            UseMasque = true;
        }
        else
        {
            UseMasque = false;
        }

    }
    // Use this for initialization
    void OnTriggerEnter(Collider other)
    {
        int i;
        string inventaire = "Inventaire :";
        if (other.tag == "Recup")
        {
            this.GetComponent<AudioSource>().Play();
            TempTab = new string[ListeObj.Length];
            for (i = 0; i < TempTab.Length; i++)
            {
                TempTab[i] = ListeObj[i];
            }
            ListeObj = new string[TempTab.Length + 1];
            for (i = 0; i < ListeObj.Length - 1; i++)
            {
                ListeObj[i] = TempTab[i];
            }
            ListeObj[ListeObj.Length - 1] = other.gameObject.name;
        }
        for (i = 0; i < ListeObj.Length; i++)
        {
            if (ListeObj[i] != "NULL")
            {
                inventaire = inventaire + ListeObj[i] + ",";
            }
        }
        InvText.text = inventaire;

    }

    void FixedUpdate()
    {

        var targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        targetVelocity = transform.TransformDirection(targetVelocity);
        targetVelocity *= speed;

        // Apply a force that attempts to reach our target velocity
        var velocity = this.GetComponent<Rigidbody>().velocity;
        var velocityChange = (targetVelocity - velocity);
        velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
        velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
        velocityChange.y = 0;
        this.GetComponent<Rigidbody>().AddForce(velocityChange, ForceMode.VelocityChange);
    }


}


