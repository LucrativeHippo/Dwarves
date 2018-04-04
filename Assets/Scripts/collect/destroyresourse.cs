using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class destroyresourse : MonoBehaviour {
  
    public int HP;
    // Use this for initialization
    void Start()
{

}
// Update is called once per frame
void Update()
{
    if (HP < 1)
    {
        Destroy(gameObject);
    }
}



}

