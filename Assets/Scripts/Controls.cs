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
}
