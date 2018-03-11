using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed;
<<<<<<< Updated upstream
=======
    //private GameObject cam;
    private void Awake()
    {
       // cam = GameObject.Find("MainCam");
    }
>>>>>>> Stashed changes
    void FixedUpdate() {
		Vector3 mov = new Vector3 (0, 0);

		mov += Input.GetKey (KeyCode.W) ? Vector3.forward : Vector3.zero;
		mov += Input.GetKey (KeyCode.S) ? Vector3.back : Vector3.zero;

		mov += Input.GetKey (KeyCode.A) ? Vector3.left : Vector3.zero;
		mov += Input.GetKey (KeyCode.D) ? Vector3.right : Vector3.zero;

		mov.Normalize ();

		transform.Translate (mov * speed);
<<<<<<< Updated upstream
=======
        //cam.transform.Translate(mov * speed);
>>>>>>> Stashed changes

        GetComponentInChildren<actionManagerPlayerRotation>().setRotation(mov);
    }
}
