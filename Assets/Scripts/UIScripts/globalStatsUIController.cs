using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class globalStatsUIController : MonoBehaviour {

    private GameObject Meta;

    private GameObject AllUIGameObject;
    private GameObject GlobalUIParent;

    private Text foodSaved;
    private Text militaryAbility;
    private Text healthMultiplier;
    private Text baseGather;

    private GameObject heatProtection;
    private GameObject coldProtection;

    [SerializeField] float updateTimeRate = 1.0f;

    void Start () {
        Meta = MetaScript.getMetaObject();
        AllUIGameObject = GameObject.Find ("AllUIObjectsCanvas");
        GlobalUIParent = AllUIGameObject.transform.GetChild (0).GetChild (3).gameObject;

        foodSaved = GlobalUIParent.transform.GetChild (0).GetChild (0).gameObject.GetComponent<Text> ();
        healthMultiplier = GlobalUIParent.transform.GetChild (1).GetChild (0).gameObject.GetComponent<Text> ();
        baseGather = GlobalUIParent.transform.GetChild (2).GetChild (0).gameObject.GetComponent<Text> ();
        militaryAbility = GlobalUIParent.transform.GetChild (3).GetChild (0).gameObject.GetComponent<Text> ();

        heatProtection = GlobalUIParent.transform.GetChild (4).gameObject;
        coldProtection = GlobalUIParent.transform.GetChild (5).gameObject;
        updateAll ();
        // StartCoroutine (updateTimer (updateTimeRate));
    }

    public void updateAll () {
        updateFoodSaved ();
        updateMilitaryAbility ();
        updateHealthMultiplier ();
        updateBaseGather ();
        updateColdProtection ();
        updateHeatProtection ();
    }

    private void updateFoodSaved () {
        foodSaved.text = Meta.GetComponent<Global_Stats> ().getFoodSaved ().ToString ();
    }

    private void updateMilitaryAbility () {
        militaryAbility.text = Meta.GetComponent<Global_Stats> ().getMilitaryAbility ().ToString ();
    }

    private void updateHealthMultiplier () {
        healthMultiplier.text = Meta.GetComponent<Global_Stats> ().getHealthMultiplier ().ToString ();
    }

    private void updateBaseGather () {
        baseGather.text = Meta.GetComponent<Global_Stats> ().getBaseGather ().ToString ();
    }

    private void updateColdProtection () {
        coldProtection.SetActive (Meta.GetComponent<Global_Stats> ().getHasColdProtection ());
    }

    private void updateHeatProtection () {
        heatProtection.SetActive (Meta.GetComponent<Global_Stats> ().getHasHeatProtection ());
    }

    // IEnumerator updateTimer (float waitForTime) {
    //     yield return new WaitForSeconds (waitForTime);
    //     updateAll ();
    //     StartCoroutine (updateTimer (waitForTime));
    // }
}
