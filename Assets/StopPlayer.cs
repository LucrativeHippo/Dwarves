using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPlayer : MonoBehaviour {

	// Use this for initialization
	void Stop () {
		Controls.focused(true);
		MetaScript.getPlayer().GetComponent<Health>().isImmortal = true;
	}
}
