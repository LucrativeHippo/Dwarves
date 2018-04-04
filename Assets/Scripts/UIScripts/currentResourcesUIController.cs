using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// works using MVC
public class currentResourcesUIController : MonoBehaviour {

    private ResourceManager resourceManager;

    private Text[] textsValuesText;

    private IEnumerator coroutine;

    void Start () {
        textsValuesText = new Text[(int)ResourceTypes.NumberOfTypes];
        for (int i = 0; i < (int)ResourceTypes.NumberOfTypes; i++) {
            textsValuesText [i] = this.transform.GetChild (i).GetChild (0).gameObject.GetComponent<Text> ();
        }
        resourceManager = MetaScript.getRes ();
        updateResourcesUI ();
    }

    void OnEnable () {
        if (resourceManager != null)
            updateResourcesUI ();
    }

    /// <summary>
    /// Updates the resources UI.
    /// </summary>
    public void updateResourcesUI () {
        for (int i = 0; i < (int)ResourceTypes.NumberOfTypes; i++) {
            textsValuesText [i].text = resourceManager.getResource (i).ToString () + "/" + resourceManager.getMaxResource (i).ToString ();
        }
    }
}
