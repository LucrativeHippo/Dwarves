using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCManagerButton : MonoBehaviour {
    private string name;
    private int number;

    public Text buttonText;
    public NPCManager npcManagerScript;

    /// <summary>
    /// Sets the NPC manager script.
    /// </summary>
    /// <param name="aNPCManagerScript">A NPC manager script.</param>
    public void setNPCManagerScript (NPCManager aNPCManagerScript) {
        npcManagerScript = aNPCManagerScript;
    }

    /// <summary>
    /// Sets the name.
    /// </summary>
    /// <param name="aName">A name.</param>
    public void setName (string aName) {
        name = aName;
        buttonText.text = name;
    }

    /// <summary>
    /// Sets the number ID.
    /// </summary>
    /// <param name="aNumber">A number.</param>
    public void setNumber (int aNumber) {
        number = aNumber;
        setListener ();
    }

    /// <summary>
    /// Sets the listener.
    /// </summary>
    public void setListener () {
        this.gameObject.GetComponent <Button> ().onClick.AddListener ((() => button_Click ()));
    }

    /// <summary>
    /// What happens when the button is Clicked.
    /// </summary>
    private void button_Click () {
        
    }

}
