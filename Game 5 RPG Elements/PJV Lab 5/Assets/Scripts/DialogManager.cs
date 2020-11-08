using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public static bool questActive; 

    public static DialogManager dialogManager;

    public GameObject dialogPanel;
    public GameObject questPanel;

    public List<string> sentences = new List<string>();
    public List<string> questSentences = new List<string>();

    public Button continueButton;
    public Button continueButtonQuest;

    public Text dialogeTextContainer, NPCNameContainer;

    public Text questTextContainer, NPCNameContainerQuest;

    int lineIndex;

    void Awake()
    {
        //get child components
        //  dialogeTextContainer = ... 
        //  NPCNameContainer = ...
        //  continueButton = ...

          continueButton.onClick.AddListener(delegate { ContinueDialog(); });
          continueButtonQuest.onClick.AddListener(delegate { ContinueQuest(); });
    }


    public static DialogManager Instance()
    {
        if (!dialogManager)
        {
            dialogManager = FindObjectOfType(typeof(DialogManager)) as DialogManager;
            if (!dialogManager)
                Debug.LogError("There needs to be one active DialogManager script on a GameObject in your scene.");
        }

        return dialogManager;
    }

    public void AddNewDialogue(string[] lines, string NPCName)
    {
        //initializeaza dialogul curent din NPC
        lineIndex = 0;
        foreach( string line in lines)
        {
            sentences.Add(line);
        }
        NPCNameContainer.text = NPCName;

        showDialog();
    }

    public void showDialog()
    {
        //afiseaza linia de dialog curenta

        if(!dialogPanel.activeSelf)
        dialogPanel.SetActive(true);

         dialogeTextContainer.text = sentences[lineIndex];

        //for (int i = 0; i < sentences.Count + 1; i++)
        //{
        //    Debug.Log("String:" + sentences[i]);
        //}
    }

    public void ContinueDialog()
    {
        int count = sentences.Count;
        //Debug.Log(count);
        if (count > lineIndex + 1)
        {
            lineIndex++;
            showDialog();
        }
        else
        {
            dialogPanel.SetActive(false);
            lineIndex = 0;
            ShowQuest();

            sentences.Clear();
        }

    }

    private void ShowQuest()
    {
        questTextContainer.text = questSentences[lineIndex];

        questPanel.SetActive(true);
    }
    public void AddQuest(string[] questLines, string NPCName)
    {
        
        foreach (string line in questLines)
        {
            questSentences.Add(line);
        }
        NPCNameContainerQuest.text = NPCName;

        if (!dialogPanel.activeSelf)
        {
            lineIndex = 0;
            ShowQuest();
        }
    }
    private void ContinueQuest()
    {
        int count = questSentences.Count;
        //Debug.Log(count);
        if(lineIndex == 2)
        {
            Da();
        }
        if (count > lineIndex + 1)
        {
            lineIndex++;
            ShowQuest();
        }
        else
        {
            questPanel.SetActive(false);

            questSentences.Clear();
        }
    }
    public void Da()
    {
        GatherQuest.activeQuest = true;
        questPanel.SetActive(false);
    }

    public void Nu()
    {
        GatherQuest.activeQuest = false;
        questPanel.SetActive(false);
    }

    
}
