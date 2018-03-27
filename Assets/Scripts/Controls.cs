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





	public GameObject enemy;

	// Alex's Dangerous Code

	public bool ALEX_TEST = false;
	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		if(ALEX_TEST){
		if(Input.GetKeyDown(KeyCode.Alpha1)){
			foreach(GameObject npc in MetaScript.GetNPC().getNPCs().ToArray()){
				if(npc!=null){
					npc.GetComponent<collect>().enabled = true;
					npc.GetComponent<Guard>().enabled = false;
					npc.GetComponent<follow>().enabled = false;
				}
			}
		}
		if(Input.GetKeyDown(KeyCode.Alpha2)){
			foreach(GameObject npc in MetaScript.GetNPC().getNPCs().ToArray()){
				if(npc!=null){
					npc.GetComponent<collect>().enabled = false;
					npc.GetComponent<Guard>().enabled = true;
					npc.GetComponent<follow>().enabled = false;
				}
			}
		}

		if(Input.GetKeyDown(KeyCode.Alpha3)){
			foreach(GameObject npc in MetaScript.GetNPC().getNPCs().ToArray()){
				if(npc!=null){
					npc.GetComponent<collect>().enabled = false;
					npc.GetComponent<Guard>().enabled = false;
					npc.GetComponent<follow>().enabled = true;
				}
			}
		}

		if(Input.GetKeyDown(KeyCode.Tab)){
			Vector3 pos = MetaScript.getPlayer().transform.position;
			for(int i=0;i<10;i++){
				float x = Random.Range(0f,1f);
				float z = Random.Range(0f,1f);
				Vector3 temp = new Vector3(x,0,z).normalized;

				Instantiate(enemy,pos+temp*9f,Quaternion.identity);
			}
		}
		}
	}
}
