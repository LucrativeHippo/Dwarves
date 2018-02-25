using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Builds quest for NPC, needs creation outside of start.
/// Disable if quest are complete
/// </summary>
public class QuestNPC : MonoBehaviour, IActionable {
    [SerializeField]
    //private int questSize = 1;
    private int rank = 10;//Random.Range(1,50);
    [SerializeField]
    private QuestBase myQuests = new QuestBase();
    public void recieveAction()
    {
        if(!this.enabled)
            return;
        
        if(myQuests.checkQuest()){
            // TODO: Send message to NPC to be a vassal of PC
            Debug.Log("QUEST COMPLETED");
            this.enabled = false;
        }else{

            Debug.Log("Attempted quest but failed. Need "+
            myQuests.GetQuestGoal().getThreshold()+" of "+
            GetQuestType().message
            );
        }
    }

    // Use this for initialization
    void Start () {
        // TODO: change this to be dependent on creation
        myQuests.addGoal(new QuestGoal(rank));

        
	}

    public void addGoal(int difficulty){
        myQuests.addGoal(new QuestGoal(difficulty));
    }
    public void addGoal(int difficulty, int index){
        myQuests.addGoal(new QuestGoal(difficulty,index));
    }
	
	// Update is called once per frame
	void Update () {
		
	}
	

    public Quests.QuestType GetQuestType(){
        int index = myQuests.GetQuestGoal().getGoalIndex();
        return Quests.questList[index];
    }
}   
