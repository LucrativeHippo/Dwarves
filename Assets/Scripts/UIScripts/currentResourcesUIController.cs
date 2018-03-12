using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class currentResourcesUIController : MonoBehaviour {

    private GameObject resourceManager;
    [SerializeField] private int updateTimer;

    private Text goldText;
    private Text woodText;
    private Text stoneText;
    private Text coalText;
    private Text ironText;
    private Text diamondText;
    private Text foodText;

    private IEnumerator coroutine;

    void Start () {
        resourceManager = GameObject.Find ("resourceManager");
        goldText = this.transform.GetChild (0).GetChild (0).gameObject.GetComponent<Text> ();
        woodText = this.transform.GetChild (1).GetChild (0).gameObject.GetComponent<Text> ();
        stoneText = this.transform.GetChild (2).GetChild (0).gameObject.GetComponent<Text> ();
        coalText = this.transform.GetChild (3).GetChild (0).gameObject.GetComponent<Text> ();
        ironText = this.transform.GetChild (4).GetChild (0).gameObject.GetComponent<Text> ();
        diamondText = this.transform.GetChild (5).GetChild (0).gameObject.GetComponent<Text> ();
        foodText = this.transform.GetChild (6).GetChild (0).gameObject.GetComponent<Text> ();

        coroutine = WaitAndUpdate (updateTimer);
        StartCoroutine (coroutine);
    }

    /// <summary>
    /// Updates the resources UI.
    /// </summary>
    private void updateResourcesUI () {
        goldText.text = resourceManager.GetComponent<ResourceManager> ().getResource (ResourceTypes.GOLD).ToString ();
        woodText.text = resourceManager.GetComponent<ResourceManager> ().getResource (ResourceTypes.WOOD).ToString ();
        stoneText.text = resourceManager.GetComponent<ResourceManager> ().getResource (ResourceTypes.STONE).ToString ();
        coalText.text = resourceManager.GetComponent<ResourceManager> ().getResource (ResourceTypes.COAL).ToString ();
        ironText.text = resourceManager.GetComponent<ResourceManager> ().getResource (ResourceTypes.IRON).ToString ();
        diamondText.text = resourceManager.GetComponent<ResourceManager> ().getResource (ResourceTypes.DIAMOND).ToString ();
        foodText.text = resourceManager.GetComponent<ResourceManager> ().getResource (ResourceTypes.FOOD).ToString ();
    }

    private IEnumerator WaitAndUpdate (float waitTime) {
        while (true) {
            yield return new WaitForSeconds (waitTime);
            updateResourcesUI ();
        }
    }
}
