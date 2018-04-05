using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcHealthBarController : MonoBehaviour, IHealthListener {

    private GameObject healthBar;

    private Health npcHealth;

    void Start () {
        setHealth (this.GetComponent<Health> ());
        healthBar = this.transform.GetChild (4).GetChild (0).gameObject;
    }

    public void publish () {
        if (npcHealth != null)
            updateHealth ();
    }

    public void setHealth (Health h) {
        if (h != null) {
            npcHealth = h;
            h.addSubscriber (this);
        }
    }

    private void updateHealth () {
        float fractionHealth = npcHealth.getHealth () / (float)npcHealth.getMaxHealth ();

        healthBar.transform.localScale = new Vector3 (fractionHealth, 1.0F, 1.0F);
    }
}
