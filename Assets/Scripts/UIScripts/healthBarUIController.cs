using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBarUIController : MonoBehaviour, IHealthListener{

    [SerializeField] int updateTimer;


    private Text healthNumberText;
    private GameObject healthBar;

    private IEnumerator coroutine;

    public void publish()
    {
        if(playerHealth != null)
            updateHealth();
    }

    private Health playerHealth;
    public void setHealth(Health h)
    {
        if(h != null){
            playerHealth = h;
            h.addSubscriber(this);
        }
    }

    void Start () {
        setHealth(MetaScript.getPlayer().GetComponent<Health>());
        healthBar = this.transform.GetChild (1).gameObject;
        healthNumberText = this.transform.GetChild (2).gameObject.GetComponent<Text> ();

        // coroutine = WaitAndUpdate (updateTimer);
        // StartCoroutine (coroutine);
    }

    private void updateHealth () {
        float temp = playerHealth.getHealth();
        float fractionHealth = temp / (float)playerHealth.getMaxHealth();

        healthNumberText.text = System.Math.Round (fractionHealth*100, 0).ToString () + "%";


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
