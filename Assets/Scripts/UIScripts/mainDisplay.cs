using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainDisplay : MonoBehaviour {

    private GameObject aNPC;

    [SerializeField] private Image npcImage;
    [SerializeField] private Text nameText;
    [SerializeField] private Text currentJobText;
    [SerializeField] private Text happynessText;

    [SerializeField] private GameObject NPCManagerCanvas;
    [SerializeField] private GameObject mainDisplayGameObject;
    [SerializeField] private GameObject moreDetailsGameObject;

    void Start () {
        NPCManagerCanvas = GameObject.Find ("NPCManagerCanvas");
        mainDisplayGameObject = NPCManagerCanvas.transform.GetChild (0).gameObject;
        moreDetailsGameObject = NPCManagerCanvas.transform.GetChild (1).gameObject;
    }

    /// <summary>
    /// Sets the NPC and all other related objects on the button.
    /// </summary>
    /// <param name="newNPC">New NP.</param>
    public void setNPC (GameObject newNPC) {
        aNPC = newNPC;

        if (aNPC != null) {
            // TODO: Make sure sprite is working.
            // setImage ();
            setName ();
            setCurrentJob ();
            setHappyness ();
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
        currentJobText.text = aNPC.GetComponent<collect> ().findingType.ToString ();
    }

    /// <summary>
    /// Sets the happyness text.
    /// </summary>
    private void setHappyness () {
        // TODO: connect happyness.
        happynessText.text = "Temp";
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
