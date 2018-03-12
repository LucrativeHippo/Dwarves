using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Builds quest for NPC, needs creation outside of start.
/// Disable if quest are complete
/// </summary>
public class QuestNPC : MonoBehaviour, IActionable {
    [ReadOnly]
    public int rank = 0;//Random.Range(1,50);
    [SerializeField]
    private QuestBase myQuests = new QuestBase();
    public void recieveAction()
    {
        if(!this.enabled)
            return;
        
        tryQuest();
    }

    private void teleportToTown(){
            transform.position = GameObject.FindGameObjectWithTag("TownCenter").transform.position+new Vector3(0.5f,0,0);
            //GetComponent<NavMeshAgent>().enabled = true;
    }
    protected void tryQuest(){
        if(myQuests.checkQuest()){
            // TODO: Send message to NPC to be a vassal of PC
            Debug.Log("QUEST COMPLETED");
            GetComponentInChildren<SpeechBubble>().setText("Quest Completed");
            MetaScript.GetNPC().addNPC(gameObject);
            
            teleportToTown();

            gameObject.GetComponent<collect>().startCollecting(ResourceTypes.WOOD);
            this.enabled = false;
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
    void Start () {
        // TODO: change this to be dependent on creation
        // myQuests.addGoal(new QuestGoal(rank));

        addGoal(GetComponent<Skills>().getIntRank());
	}

    public void addGoal(int difficulty){
        myQuests.addGoal(new QuestGoal(difficulty));
        rank += difficulty;
    }
    public void addGoal(int difficulty, int index){
        myQuests.addGoal(new QuestGoal(difficulty,index));
        rank += difficulty;
    }
	
	// Update is called once per frame
	void Update () {
		
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
    }

    public Quests.QuestType GetQuestType(){
        int index = myQuests.GetQuestGoal().getGoalIndex();
        return Quests.list[index];
    }
}   
