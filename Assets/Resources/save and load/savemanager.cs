using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class savemanager : MonoBehaviour {
    private static savemanager instance;
    public List<saveableobject> saveobjects { get; private set; }
   

    public static savemanager Instance
    {
        get
        {
            if(instance==null){

                instance = GameObject.FindObjectOfType<savemanager>();

            }
            return instance;
        }
       
    }

  
    // Use this for initialization

    void Awake()
    {
        saveobjects = new List<saveableobject>();
    }

 

    public  void savef(){
        PlayerPrefs.SetInt("objectcount",saveobjects.Count);

        for (int i = 0; i < saveobjects.Count;i++){
            saveobjects[i].savefunction(i);

        }



         }



    public void Load(){

        foreach(saveableobject obj in saveobjects){

            if(obj !=null){

                Destroy(obj.gameObject);
            }
        }
        saveobjects.Clear();



        int objectcount = PlayerPrefs.GetInt("objectcount");
        for (int i = 0; i< objectcount;i++){


            string[] value = PlayerPrefs.GetString(i.ToString()).Split('_');
            GameObject t = null;
            switch (value[0]) {
            
                case"building":
                   t = Instantiate(Resources.Load("building") as GameObject);
                    break;

                case "player":
                     t = Instantiate(Resources.Load("player") as GameObject);
                    break;
                case "enemy":
                     t = Instantiate(Resources.Load("enemy") as GameObject);
                    break;

            }

            if(t!=null){
                t.GetComponent<saveableobject>().load(value);

            }

           // Debug.Log(value);
            //GameObject t = Instantiate(Resources.Load("target") as GameObject);
           
        }

    }
    public Vector3 stringtovector(string value){
        //(1, 23, 3)
        value = value.Trim(new char[] { '(', ')' });
        //after look like 1, 23, 3
        value = value.Replace(" ", "");
        //now 1,23,3
        string[] pos = value.Split(',');
        //[0]=1 [1]=23 [2]=3
        return new Vector3(float.Parse(pos[0]), float.Parse(pos[1]), float.Parse(pos[2]));

    }


    public Quaternion stringtoquaternion(string value){
        return Quaternion.identity;


    }

  

	
}
