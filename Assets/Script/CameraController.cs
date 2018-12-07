using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    void SetCursorState()
    {
        Cursor.lockState=CursorLockMode.Locked;
        Cursor.visible=false;
    }

    void Start()
    {
        SetCursorState();
       
    }
	
	// Update is called once per frame
	void Update () {

		var Rotx = Input.GetAxis("Mouse X") * Time.deltaTime * 150.0f;
		var Roty = Input.GetAxis("Mouse Y") * Time.deltaTime * 150.0f;
		
		transform.Rotate(Vector3.right * Roty);
        transform.Rotate(Vector3.up * Rotx, Space.World);

        //this.transform.localEulerAngles = new Vector3(Mathf.Clamp(this.transform.localEulerAngles.x, 0.0f, 0.0f), this.transform.localEulerAngles.y, this.transform.localEulerAngles.z);

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}

