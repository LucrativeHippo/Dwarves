using System.Collections;
using System.Collections.Generic;
using UnityEngine;
enum ObjectType{p1,p2,target}
public abstract class saveableobject : MonoBehaviour {
    protected string save;
    [SerializeField]
  private ObjectType type;
    // Use this for initialization
  
    private void Start () {
        savemanager.Instance.saveobjects.Add(this);
        PlayerPrefs.SetInt("age", 30);
        int aage = PlayerPrefs.GetInt("age");
        Debug.Log(aage);
       
       // savemanager.Instance.savef();	
	}
	
    public virtual void savefunction(int id){
        PlayerPrefs.SetString(id.ToString(),type +"_"+transform.position.ToString());
       

    }
    public virtual void load(string[] values){


        transform.localPosition =savemanager.Instance.stringtovector(values[1]);

    }
    public  void destroysave(){



    }
	
}
