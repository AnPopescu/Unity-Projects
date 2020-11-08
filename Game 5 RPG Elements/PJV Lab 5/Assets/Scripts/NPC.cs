using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable
{
    public string[] sentences; //se pot configura liniile de dialog in editor

    //public Item[] flacari;
    
    public GatherQuest quest;

    public override void Interact()
    {
        //if (Quest.activeQuest)
        //    assignedQuest = true;

        //base.Interact(); // se apeleaza metoda parinte
        //if (!assignedQuest)
        //{
        //    DialogManager.Instance().AddNewDialogue(sentences, name);
        //    DialogManager.Instance().AddQuest(gameObject.GetComponent<Quest>().QuestDialog(), name);
        //}
        //else if(assignedQuest)
        //{

        //}
    }
    public virtual void CheckQuest()
    {
        if (quest.completed)
        {
            quest.GiveReward();
        }
        else
            Debug.Log("Nu ai completat misiunea");
    }
}
