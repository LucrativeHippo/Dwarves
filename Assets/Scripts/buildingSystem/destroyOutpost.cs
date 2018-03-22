using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyOutpost : MonoBehaviour, IActionable {
    [SerializeField]
    KeyCode key;

    public void recieveAction()
    {
            MetaScript.getOPController().destroyOutpost();
            Destroy(gameObject);
    }


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
