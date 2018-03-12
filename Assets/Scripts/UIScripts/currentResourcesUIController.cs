using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// works using MVC
public class currentResourcesUIController : MonoBehaviour {

    private GameObject resourceManager;




    private IEnumerator coroutine;

    void Start () {
        updateResourcesUI();
    }

    /// <summary>
    /// Updates the resources UI.
    /// </summary>
    public void updateResourcesUI () {
        for(int i=0;i<(int)ResourceTypes.NumberOfTypes;i++){
            GameObject g = GameObject.Find(((ResourceTypes)i).ToString().ToLower()+"Text");
            if(g != null){
                g.GetComponent<Text>().text = MetaScript.getRes().getResource(i).ToString();
            }else{
                Debug.Log("HEY!! This doesn't exist: "+((ResourceTypes)i).ToString().ToLower());
            }
        }
    }
}
