using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainDisplay : MonoBehaviour, IHealthListener {

    private GameObject aNPC;

    private Image npcImage;
    private Text nameText;
    private Text currentJobText;
    private Text healthText;

    private GameObject AllUIObjectsGameObject;
    private GameObject mainDisplayGameObject;
    private GameObject moreDetailsGameObject;

    private Health npcHealth;

    void Start () {
        AllUIObjectsGameObject = GameObject.Find ("AllUIObjectsCanvas");
        mainDisplayGameObject = AllUIObjectsGameObject.transform.GetChild (1).GetChild (0).gameObject;
        moreDetailsGameObject = AllUIObjectsGameObject.transform.GetChild (1).GetChild (1).gameObject;
    }

    /// <summary>
    /// Sets the NPC and all other related objects on the button.
    /// </summary>
    /// <param name="newNPC">New NP.</param>
    public void setNPC (GameObject newNPC) {
        npcImage = this.transform.GetChild (0).gameObject.GetComponent<Image> ();
        nameText = this.transform.GetChild (1).gameObject.GetComponent<Text> ();
        currentJobText = this.transform.GetChild (2).gameObject.GetComponent<Text> ();
        healthText = this.transform.GetChild (3).gameObject.GetComponent<Text> ();

        aNPC = newNPC;

        if (aNPC != null) {
            // TODO: Make sure sprite is working.
            // setImage ();
            setName ();
            setCurrentJob ();
            setHealth (aNPC.GetComponent<Health> ());
            updateHealth ();
        } else {
            Debug.Log ("NPC Manager Error, aNPC is Null.");
        }

        this.gameObject.GetComponent<Button> ().onClick.AddListener (() => buttonClicked ());
    }

    /// <summary>
    /// Sets the name text.
    /// </summary>
    private void setName () {
        nameText.text = aNPC.name;
    }

    /// <summary>
    /// Sets the current job text.
    /// </summary>
    private void setCurrentJob () {
        if (aNPC.GetComponent<follow> ().enabled == true) {
            Debug.Log ("Following in setRole");
            currentJobText.text = "Following";
        } else if (aNPC.GetComponent<Guard> ().enabled == true) {
            Debug.Log ("Guarding in setRole");
            currentJobText.text = "Guarding";
        } else {
            currentJobText.text = aNPC.GetComponent<collect> ().getFindingType ();
        }
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
        healthText.text = "Health: " + (System.Math.Round (fractionHealth * 100, 0)).ToString () + "%";
    }

    /// <summary>
    /// Sets the NPC image.
    /// </summary>
    private void setImage () {
        Sprite aNPCSprite = aNPC.GetComponent<SpriteRenderer> ().sprite; 
        if (aNPCSprite != null) {
            npcImage.GetComponent<Image> ().sprite = aNPCSprite;
        } else {
            Debug.Log (aNPC.name + " has no Sprite to display.");
        }
    }

    /// <summary>
    /// When Button is clicked disable this UI, enable More Details UI and pass the more details UI the NPC.
    /// </summary>
    private void buttonClicked () {
        mainDisplayGameObject.SetActive (false);
        moreDetailsGameObject.SetActive (true);
        moreDetailsGameObject.GetComponent<moreDetailsUIController> ().setNPC (aNPC);
    }
}
