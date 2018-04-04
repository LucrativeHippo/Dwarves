using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed;
    private Animator animator;
    private Controls controls;
   // public AudioSource sound;
    //private GameObject cam;
    private void Awake()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
        controls = MetaScript.GetControls();
        // cam = GameObject.Find("MainCam");
    }


    void FixedUpdate() {
		Vector3 mov = new Vector3 (0, 0);
        bool noAnim = true;
        if(animator!=null){
            GetComponent<AudioSource>().Pause();
            animator.SetBool("moveUp", false);
            animator.SetBool("moveDown", false);
            animator.SetBool("moveLeft", false);
            animator.SetBool("moveRight", false);
            animator.SetBool("attack", false);
        }
        

        if(controls.key(controls.Forward)){
            
            mov += Vector3.forward;
            if (animator != null && noAnim)
            {GetComponent<AudioSource>().UnPause();
                noAnim = false;
               
               animator.SetBool("moveUp", true);
               
            }
          
        }
        if (controls.key(controls.Backward))
        {
            mov += Vector3.back;
            if (animator != null && noAnim)
            {
                noAnim = false;
                GetComponent<AudioSource>().UnPause();
                animator.SetBool("moveDown", true);
            }
        }
        if (controls.key(controls.Left))
        {
           
            mov += Vector3.left;
            if (animator != null && noAnim)
            {
               
                noAnim = false;
                GetComponent<AudioSource>().UnPause();
                animator.SetBool("moveLeft", true);
            }
        }
        if (controls.key(controls.Right))
        {
            mov += Vector3.right;
            if (animator != null && noAnim)
            {
                noAnim = false;
                GetComponent<AudioSource>().UnPause();
                animator.SetBool("moveRight", true);
            }
        }
        if (Input.GetKey(KeyCode.F))
        {
          
            if (animator != null && noAnim)
            {
                noAnim = false;
                animator.SetBool("attack", true);
            }
        }

		mov.Normalize ();

		transform.Translate (mov * speed);

        //cam.transform.Translate(mov * speed);


        GetComponentInChildren<actionManagerPlayerRotation>().setRotation(mov);
    }
  
}
