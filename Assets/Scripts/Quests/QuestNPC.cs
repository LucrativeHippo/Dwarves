using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

/// <summary>
/// Builds quest for NPC, needs creation outside of start.
/// Disable if quest are complete
/// </summary>
public class QuestNPC : MonoBehaviour, IActionable {
    [ReadOnly]
    public int rank = 0;//Random.Range(1,50);
    [SerializeField]
    private QuestBase myQuests = new QuestBase();
    [SerializeField]
    public bool finishQuest = false;
	bool hasSound = false;
	bool spoke = true;
    public void recieveAction()
    {
        if(!this.enabled)
            return;
        
        // Popup message
        activateUI();
        //tryQuest();
    }

    /// <summary>
    /// Converts NPC to be an owned NPC and immediately starts gathering wood
    /// </summary>
    public void TakeSoul(){
            MetaScript.GetNPC().addNPC(gameObject);
            gameObject.tag = "OwnedNPC";
            //teleport to town
            transform.position = MetaScript.getTownCenter().transform.position+new Vector3(0.5f,0,0);
            transform.SetParent(MetaScript.getMetaObject().transform);

            
            gameObject.GetComponent<collect>().enabled = true;
            gameObject.GetComponent<collect>().startCollecting(ResourceTypes.WOOD);
            Destroy(this);
            //GetComponent<NavMeshAgent>().enabled = true;
    }
    protected void tryQuest(){
        if(myQuests.checkQuest()){
            if(MetaScript.getRes().roomForResource(ResourceTypes.POPULATION, 1))
            {
                Debug.Log("QUEST COMPLETED");
                GetComponentInChildren<SpeechBubble>().setText("Quest Completed");

                MetaScript.Poof(transform.position);
                TakeSoul();
            }
            else
            {
                Debug.Log("Not enough population");
                GetComponentInChildren<SpeechBubble>().setText("You require additional Pylons... I mean houses");
            }
            

        }else{

            Debug.Log("Attempted quest but failed. Need "+
            myQuests.GetQuestGoal().getThreshold()+" of "+
            GetQuestType().Name
            );

            
            gameObject.GetComponentInChildren<SpeechBubble>().setText("Need "+
            myQuests.GetQuestGoal().getThreshold()+" "+
            GetQuestType().Name);
            
        }
    }

    // Use this for initialization
    // void Update () {

    //     if(CompareTag("OwnedNPC")){
    //         GetComponent<QuestNPC>().TakeSoul();
    //     }
        
	// }

    public void addGoal(int difficulty){
        myQuests.addGoal(new QuestGoal(difficulty));
        rank += difficulty;
    }
    public void addGoal(int difficulty, int index){
        myQuests.addGoal(new QuestGoal(difficulty,index));
        rank += difficulty;
    }



    public void setRank(int r){
        if(r>0){
            myQuests = new QuestBase();
        }
    }
	
    void OnValidate() {
        rank = 0;
        foreach (QuestGoal g in myQuests.questPath){
            rank += g.getThreshold()*Quests.list[g.getGoalIndex()].difficulty;
        }
        if(finishQuest){
            myQuests = new QuestBase();
            recieveAction();
        }
    }

    public Quests.QuestType GetQuestType(){
        int index = myQuests.GetQuestGoal().getGoalIndex();
        return Quests.list[index];
    }

    
    private GameObject AllUIObjects;
    private GameObject upgradePrompt;

    private GameObject confirmButton;
    private GameObject cancelButton;

    private Text nameText;
    private Text costText;
    private Text moreResourcesRequiredText;

    public void activateUI(){
        AllUIObjects.transform.GetChild (2).gameObject.SetActive (true);
        upgradePrompt.SetActive (true);
        confirmButton.GetComponentInChildren<Text>().text = "Recruit";
        nameText.text = "Do you wish to recruit this person?";
        costText.text = myQuests.GetQuestGoal().ToString();
        moreResourcesRequiredText.text = "";
        setListener ();
    }

    void doUpgrade () {
        closePrompt ();
        tryQuest();
    }

    void Start () {
		if (GetComponent<AudioSource> () != null) {
			hasSound = true;
		}
		AllUIObjects = GameObject.Find ("AllUIObjectsCanvas");
        upgradePrompt = AllUIObjects.transform.GetChild (2).GetChild (1).gameObject;
        confirmButton = upgradePrompt.transform.GetChild (0).gameObject;
        cancelButton = upgradePrompt.transform.GetChild (1).gameObject;
        costText = upgradePrompt.transform.GetChild (2).gameObject.GetComponent<Text> ();
        nameText = upgradePrompt.transform.GetChild (3).gameObject.GetComponent<Text> ();
        moreResourcesRequiredText = upgradePrompt.transform.GetChild (4).gameObject.GetComponent<Text> ();
		Invoke ("unSpoke", 3);
    }

	void Update() {
		if ((!spoke)&&hasSound) {
			GetComponent<AudioSource> ().Play ();
			spoke = true;
			Invoke ("unSpoke", 45); //Time till we nexxt play the SFX
		}
	}

	void unSpoke(){
		spoke = false;
	}
	
    private void setListener () {
        confirmButton.GetComponent<Button> ().onClick.RemoveAllListeners();
        cancelButton.GetComponent<Button> ().onClick.RemoveAllListeners();
        confirmButton.GetComponent<Button> ().onClick.AddListener (() => doUpgrade ());
        cancelButton.GetComponent<Button> ().onClick.AddListener (() => closePrompt ());
    }

    private void closePrompt () {
        confirmButton.GetComponentInChildren<Text>().text = "Upgrade";
        upgradePrompt.SetActive (false);
        AllUIObjects.transform.GetChild (2).gameObject.SetActive (false);
    }
}   
