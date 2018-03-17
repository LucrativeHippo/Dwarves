using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed;
    private Animator animator;

    //private GameObject cam;
    private void Awake()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
        // cam = GameObject.Find("MainCam");
    }


    void FixedUpdate() {
		Vector3 mov = new Vector3 (0, 0);
        bool noAnim = true;
        if(animator!=null){
            animator.SetBool("moveUp", false);
            animator.SetBool("moveDown", false);
            animator.SetBool("moveLeft", false);
            animator.SetBool("moveRight", false);
        }

        if (Input.GetKey(KeyCode.W)) 
        {
            mov += Vector3.forward;
            if (animator != null && noAnim)
            {
                noAnim = false;
                animator.SetBool("moveUp", true);
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            mov += Vector3.back;
            if (animator != null && noAnim)
            {
                noAnim = false;
                animator.SetBool("moveDown", true);
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            mov += Vector3.left;
            if (animator != null && noAnim)
            {
                noAnim = false;
                animator.SetBool("moveLeft", true);
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            mov += Vector3.right;
            if (animator != null && noAnim)
            {
                noAnim = false;
                animator.SetBool("moveRight", true);
            }
        }

		mov.Normalize ();

		transform.Translate (mov * speed);

        //cam.transform.Translate(mov * speed);


        GetComponentInChildren<actionManagerPlayerRotation>().setRotation(mov);
    }
}
