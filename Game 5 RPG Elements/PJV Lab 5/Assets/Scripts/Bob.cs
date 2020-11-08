using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bob : NPC
{
    // Start is called before the first frame update
    private void Awake()
    {
        quest = GetComponent<GatherQuest>();
    }
    public override void Interact()
    {
        if (GatherQuest.activeQuest)
            assignedQuest = true;

        base.Interact(); // se apeleaza metoda parinte
        if (!assignedQuest)
        {   Debug.Log("Am lauat la cunostinta");
            DialogManager.Instance().AddNewDialogue(sentences, name);
            DialogManager.Instance().AddQuest(gameObject.GetComponent<GatherQuest>().QuestDialog(), name);
        }
        else if (assignedQuest)
        {
            CheckQuest();
        }
    }
    public override void CheckQuest()
    {
        if (quest.CheckGoal())
        {
            quest.GiveReward();
        }
        else
            Debug.Log("Nu ai completat misiunea");
    }
}
