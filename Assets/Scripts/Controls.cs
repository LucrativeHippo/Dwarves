using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {
	public KeyCode Forward = KeyCode.W,
	Backward = KeyCode.S,
	Right = KeyCode.D,
	Left = KeyCode.A;

	public KeyCode Action = KeyCode.F;
	public KeyCode Torch = KeyCode.E;
	public KeyCode Outpost = KeyCode.V;
	public KeyCode TownPortal = KeyCode.T;
	public KeyCode ExitUI = KeyCode.Escape;
	public KeyCode Attack = KeyCode.Space;
	public KeyCode HideBell = KeyCode.Q;
	public KeyCode Collect = KeyCode.Alpha1;
	public KeyCode Guard = KeyCode.Alpha2;
	public KeyCode Follow = KeyCode.Alpha3;

	public bool FocusedInput = false;

	public bool keyDown(KeyCode key){
		return !FocusedInput && Input.GetKeyDown(key);
	}

	public bool key(KeyCode key){
		return !FocusedInput && Input.GetKey(key);
	}

	public static void focused(bool yes){
		MetaScript.GetControls().FocusedInput = yes;
	}

	public bool guards = false;
	public bool Guarding(){
		return guards;
	}
	void Update(){
        if(keyDown(Follow)){
			guards = false;
            foreach(GameObject npc in MetaScript.GetNPC().getNPCs().ToArray()){
                if(npc!=null){
                    npc.GetComponent<collect>().enabled = true;
                    npc.GetComponent<Guard>().enabled = false;
                    npc.GetComponent<follow>().enabled = false;
                }
            }
        }
        if(keyDown(Guard)){
			guards = true;
            foreach(GameObject npc in MetaScript.GetNPC().getNPCs().ToArray()){
                if(npc!=null){
                    npc.GetComponent<collect>().enabled = false;
                    npc.GetComponent<Guard>().enabled = true;
                    npc.GetComponent<follow>().enabled = false;
                }
            }
        }

        if(keyDown(Collect)){
			guards = false;
            foreach(GameObject npc in MetaScript.GetNPC().getNPCs().ToArray()){
                if(npc!=null){
                    npc.GetComponent<collect>().enabled = false;
                    npc.GetComponent<Guard>().enabled = false;
                    npc.GetComponent<follow>().enabled = true;
                }
            }
        }
	}
}
