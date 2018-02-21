using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class destroyresourse : MonoBehaviour {
  
    public int waterHP;
    // Use this for initialization
    void Start()
{

}
// Update is called once per frame
void Update()
{
    if (waterHP < 1)
    {
        Destroy(gameObject);
    }
}



    private void OnTriggerStay(Collider other)
    {
        waterHP -= 1;
    }
}

