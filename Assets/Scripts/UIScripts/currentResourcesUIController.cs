using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class currentResourcesUIController : MonoBehaviour {

    private GameObject resourceManager;
    [SerializeField] private int updateTimer;

    private Text goldText;
    private bool idle = true;

    void Start () {
        updateHUD();
    }

    IEnumerator wait(){
        idle = false;
        
        yield return new WaitForSeconds (updateTimer);
        updateHUD();
        idle = true;
    }

    private void updateHUD(){
        for(int i=0;i<(int)ResourceTypes.NumberOfTypes;i++){
            GameObject g = GameObject.Find(((ResourceTypes)i).ToString().ToLower()+"Text");
            if(g != null){
                g.GetComponent<Text>().text = MetaScript.getRes().getResource(i).ToString();
            }else{
                Debug.Log("HEY!! "+((ResourceTypes)i).ToString().ToLower());
            }
        }
    }

    void Update () {
        if(idle)
            StartCoroutine(wait());
    }
}
