using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestNPC : MonoBehaviour, IActionable {
    [SerializeField]
    private int questSize = 1;
    [SerializeField]
    private int [] questIndex;
    private QuestBase myQuests;
    public void recieveAction()
    {
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
        myQuests = new QuestBase(questSize, Random.Range(1,50));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	

    public Quests.QuestType GetQuestType(){
        int index = myQuests.GetQuestGoal().getGoalIndex();
        return Quests.questList[index];
    }
}   
