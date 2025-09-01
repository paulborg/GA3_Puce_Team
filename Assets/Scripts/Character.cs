using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Character : MonoBehaviour
{
    public DialogueSO dialogueData;

    private int dialogueIndex;
    private DialogueController dialogueController;
    private bool isDialogueActive;

    public TraitsManager traitsManager;

    private void Start()
    {
        dialogueController = DialogueController.Instance;
    }

    private void Awake()
    {
        isDialogueActive = false;
    }

    public void StartDialogue()
    {
        //Debug.Log($"Starting dialogue for {this.gameObject.name} using DialogueSO: {dialogue.name}");
        isDialogueActive = true;
        dialogueIndex = 0;

        dialogueController.SetDialogueText(dialogueData.dialogueLines[dialogueIndex]);
        dialogueController.ShowDialogueUI(true);
        dialogueController.SetCharInfo(dialogueData.charName);




        NextLine();

    }

    public void NextLine()
    {
        Debug.Log($"NextLine() called on: {gameObject.name}");
        dialogueController.ClearChoices();

        if (dialogueIndex >= dialogueData.dialogueLines.Length)
        {
            dialogueController.ClearChoices();
            EndDialogue();
            return;
        }

        dialogueController.SetDialogueText(dialogueData.dialogueLines[dialogueIndex]);

        foreach(DialogueChoice dialogueChoice in dialogueData.choices)
        {
            if(dialogueChoice.dialogueIndex == dialogueIndex)
            {
                DisplayChoices(dialogueChoice);
                return;
            }
        }
        dialogueIndex++; 
    }

    //if (++dialogueIndex > dialogueData.dialogueLines.Length)
    //{
    //    EndDialogue();
    //}

    void DisplayChoices(DialogueChoice choices)
    {
        for (int i = 0; i < choices.choices.Length; i++)
        {
            int nextIndex = choices.nextDialogueIndexes[i];
            string trait = "";
            float delta = 0f;

            if (choices.traitToUpdate != null && i < choices.traitToUpdate.Length)
            {
                trait = choices.traitToUpdate[i];
            }

            if (choices.traitDelta != null && i < choices.traitDelta.Length)
            {
                delta = choices.traitDelta[i];
            }

            string traitToUpdate = trait;
            float traitDelta = delta;

            dialogueController.CreateChoiceButton(choices.choices[i], () =>
            {
                if (!string.IsNullOrEmpty(traitToUpdate))
                {
                    traitsManager.UpdateTraits(traitToUpdate, traitDelta);
                }

                ChooseOption(nextIndex);
            });
        }   
    }

    void ChooseOption(int nextIndex)
    {
        dialogueIndex = nextIndex;
        dialogueController.ClearChoices();
        NextLine();
    }


   public void EndDialogue()
    {
        isDialogueActive = false;
        dialogueController.SetDialogueText("");
        dialogueController.ShowDialogueUI(false);
        dialogueController.ClearChoices();
    }

}



