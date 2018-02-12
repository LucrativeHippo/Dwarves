using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class specific: saveableobject {
  //  private float speed;
   //   private float strength;
    // Use this for initialization
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update () {
       
	}
    public override void savefunction(int id){
        base.savefunction(id);


    }
    public override void load(string[] values){
        base.load(values);


    }
}
