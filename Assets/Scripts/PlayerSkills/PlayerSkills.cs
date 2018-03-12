using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills : MonoBehaviour {

    public GameObject campfire;
    public GameObject player;

    private void Start()
    {
        player = GameObject.Find("player").gameObject.GetComponentInChildren<actor>().gameObject;
    }

    // Update is called once per frame
    void Update () {
        if (player != null)
        {
            if (Input.GetKey(KeyCode.V))
            {
                Debug.Log("Pressed skill");
                if (campfire != null)
                {
                    Instantiate(campfire, player.transform.position, Quaternion.identity);
                }

            }
        }
        
    }
}
