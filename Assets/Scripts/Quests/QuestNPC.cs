using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    protected void tryQuest(){
        if(myQuests.checkQuest()){
            // TODO: Send message to NPC to be a vassal of PC
            Debug.Log("QUEST COMPLETED");
            gameObject.GetComponent<SpriteRenderer>().color = Color.green;
            gameObject.GetComponent<collect>().findingType = ResourceTypes.WOOD;
            gameObject.GetComponent<collect>().getResource = true;
            this.enabled = false;
        }else{

            Debug.Log("Attempted quest but failed. Need "+
            myQuests.GetQuestGoal().getThreshold()+" of "+
            GetQuestType().message
            );

            /*
            gameObject.GetComponent<SpeechBubble>().setText("Need "+
            myQuests.GetQuestGoal().getThreshold()+" "+
            GetQuestType().message);
            */
            Debug.Log(("Need " +
            myQuests.GetQuestGoal().getThreshold() + " " +
            GetQuestType().message));
        }
    }

    // Use this for initialization
    void Start () {
        // TODO: change this to be dependent on creation
        // myQuests.addGoal(new QuestGoal(rank));

        
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
	

    public Quests.QuestType GetQuestType(){
        int index = myQuests.GetQuestGoal().getGoalIndex();
        return Quests.questList[index];
    }
}   
