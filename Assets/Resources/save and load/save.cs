using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class save : MonoBehaviour {
    public Transform cube;
    GameObject a;
	// Use this for initialization
	void Start () {
        List<string> btnsName = new List<string>();  
        btnsName.Add("BtnPlay");  
        btnsName.Add("BtnShop");  
        btnsName.Add("BtnLeaderboards");  
  
        foreach(string btnName in btnsName)  
        {  
            GameObject btnObj = GameObject.Find(btnName);  
            Button btn = btnObj.GetComponent<Button>();  
            btn.onClick.AddListener(delegate() {  
                this.OnClick(btnObj);   
            });  
        }   
	}
	
	// Update is called once per frame
	void Update () {
		
	}
  


    public void OnClick(GameObject sender)  
    {  
        switch (sender.name)  
        {  
        case "play":
                savestuff();  
            break;  
            case "load":
                loadstuff();  
            break;  
        }  
    }  

    void savestuff(){
        PlayerPrefs.SetFloat("posx",cube.position.x);
        PlayerPrefs.SetFloat("posy", cube.position.y);
        PlayerPrefs.SetFloat("posz", cube.position.z);



    }

    void loadstuff(){
        cube.position = new Vector3(PlayerPrefs.GetFloat("posx"), PlayerPrefs.GetFloat("posy"), PlayerPrefs.GetFloat("posz"));

    }
}
