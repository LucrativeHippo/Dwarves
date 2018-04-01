using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateSwitch : MonoBehaviour {

    private GameObject currentNPC;

    [SerializeField] private Text buttonText;

    private GameObject moreDetails;

    void Start () {
        moreDetails = GameObject.Find ("npcManagerMoreDetailsScrollView");
    }

    public void setNPC(GameObject aNPC) {
        currentNPC = aNPC;
    }

    public void setGuardButton (GameObject aNPC) {
        currentNPC = aNPC;
		buttonText.text = "Guard";
		GetComponent<Button> ().onClick.AddListener (() => guard_Click ());
    }
	public void setFollowButton(GameObject aNPC){
		currentNPC = aNPC;
		buttonText.text = "Follow";
		GetComponent<Button> ().onClick.AddListener (() => follow_Click ());
	}


    private void guard_Click(){
		disableCollect(currentNPC);
		setFollow(false, currentNPC);
		setGuard(true, currentNPC);
        this.transform.parent.parent.gameObject.SetActive (false);
        moreDetails.GetComponent<moreDetailsUIController> ().setRole ("Guard");
	}

	private void follow_Click(){
		disableCollect(currentNPC);
		setGuard(false, currentNPC);
		setFollow(true, currentNPC);
		transform.parent.parent.gameObject.SetActive (false);
		moreDetails.GetComponent<moreDetailsUIController>().setRole("Follow");
	}

    private void button_Click () {
        currentNPC.GetComponent<collect>().enabled = true;
        this.transform.parent.parent.gameObject.SetActive (false);
        moreDetails.GetComponent<moreDetailsUIController> ().setRole ();
    }

	public static void setGuard(bool b, GameObject npc){
		npc.GetComponent<Guard>().enabled = b;
		stopAgent(!b,npc);
	}

	public static void setFollow(bool b, GameObject npc){
		npc.GetComponent<follow>().enabled = b;
		stopAgent(!b,npc);
	}
	
	public static void disableCollect(GameObject npc){
		npc.GetComponent<collect>().enabled = false;
		stopAgent(true,npc);
	}

	private static void stopAgent(bool b, GameObject npc){
		npc.GetComponent<UnityEngine.AI.NavMeshAgent>().isStopped = b;
	}

}
