using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills : MonoBehaviour {
    [SerializeField]
    private GameObject campfire;
    private GameObject player;
    [SerializeField]
    private float timer = 2.0f;

    private float timer2;

    private void Start()
    {
        timer2 = timer;
        player = MetaScript.getPlayer().GetComponentInChildren<actor>().gameObject;
    }

    // Update is called once per frame
    void Update () {
        if (player != null)
        {
            if (Input.GetKey(KeyCode.V))
            {
                
                if ((campfire != null) && CoolDown())
                {
                    Instantiate(campfire, player.transform.position, Quaternion.identity);
                }

            }
        }
        
        
    }

    public bool CoolDown()
    {
        timer += Time.deltaTime;

        if (timer >= timer2)
        {
            timer = 0;
            return true;
            
        }
        return false;
    }
}
