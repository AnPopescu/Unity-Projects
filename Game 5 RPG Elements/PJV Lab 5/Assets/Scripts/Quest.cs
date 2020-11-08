using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : Goal
{
    public bool completed = false;
    static public bool activeQuest = false;

    public string[] questSentences;
    
    public virtual string[] QuestDialog()
    {
        return questSentences;
    }

    public virtual void GiveReward()
    {
        Debug.Log("Felicitari! Give Reward");
    }
}