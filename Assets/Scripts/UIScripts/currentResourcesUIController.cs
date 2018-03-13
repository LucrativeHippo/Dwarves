using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// works using MVC
public class currentResourcesUIController : MonoBehaviour {

    private GameObject resourceManager;

    private Text[] textsValuesText;

    private IEnumerator coroutine;

    void Start () {
        textsValuesText = new Text[(int)ResourceTypes.NumberOfTypes - 1];
        for (int i = 0; i < (int)ResourceTypes.NumberOfTypes - 1; i++) {
            textsValuesText [i] = this.transform.GetChild (i).GetChild (0).gameObject.GetComponent<Text> ();
        }
        updateResourcesUI ();
    }

    /// <summary>
    /// Updates the resources UI.
    /// </summary>
    public void updateResourcesUI () {
        for (int i = 0; i < (int)ResourceTypes.NumberOfTypes - 1; i++) {
            textsValuesText [i].text = MetaScript.getRes ().getResource (i).ToString () + "/" + MetaScript.getRes().getMaxResource(i).ToString();
        }
    }
}
