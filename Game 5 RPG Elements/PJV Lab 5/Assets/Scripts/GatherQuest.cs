using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatherQuest : Quest
{
    Item fire;
    int count = 0;
    private void Update()
    {
        CheckGoal();
    }
    public void CheckIfActive()
    {
        if (DialogManager.questActive == true)
            activeQuest = true;
    }

    // Start is called before the first frame update
    public override string[] QuestDialog()
    {
        questSentences = new string[3];
        questSentences[0] = "Exista 4 obiecte de aur in apropiere";
        questSentences[1] = "Vreau sa imi aduci cel putin unul.";
        questSentences[2] = "Treci la treaba , te astept aici.";
        return questSentences;
    }

    public override bool CheckGoal()
    {
        //DialogManager.questActive = false;
        //base.CheckGoal();
       foreach(Item i in Inventory.instance.items)
        {
            count++;
        }

        if (count == 2)
        {
            completed = true;
        }
        return completed;
    }

    public override void GiveReward()
    {
            base.GiveReward();
    }
}
