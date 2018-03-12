using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBarUIController : MonoBehaviour {

    [SerializeField] int updateTimer;

    private GameObject player;

    private Text healthNumberText;
    private GameObject healthBar;

    private IEnumerator coroutine;

    void Start () {
        player = GameObject.FindWithTag ("Player");
        healthBar = this.transform.GetChild (1).gameObject;
        healthNumberText = this.transform.GetChild (2).gameObject.GetComponent<Text> ();

        coroutine = WaitAndUpdate (updateTimer);
        StartCoroutine (coroutine);
    }

    private void updateHealth () {
        float temp = player.GetComponent<Health> ().health;
        healthNumberText.text = System.Math.Round (temp, 0).ToString () + "%";

        float fractionHealth = temp / 100;

        healthBar.transform.localScale = new Vector3 (fractionHealth, 1.0F, 1.0F);
    }

    private IEnumerator WaitAndUpdate (float waitTime) {
        while (true) {
            yield return new WaitForSeconds (waitTime);
            //TODO: make sure the player has health.
//            updateHealth ();
        }
    }
}
