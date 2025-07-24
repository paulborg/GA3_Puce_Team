using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI actorName;
    public TextMeshProUGUI messageText;
    public RectTransform backgroundBox;
    CanvasGroup dialogueGroup;

    Message[] currentMessages;
    Actor[] currentActors;
    int activeMessage = 0;
    public static bool isActive = false;

    public void OpenDialogue(Message[] messages, Actor[] actors)
    {
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;
        isActive = true;

        Debug.Log("Dialogue started! " + messages.Length + " messages loaded.");
        DisplayMessage();
        dialogueGroup.LeanAlpha(1, 0.25f);
    }

    void DisplayMessage()
    {   
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.message;

        Actor actorToDisplay = currentActors[messageToDisplay.actorID];
        actorName.text = actorToDisplay.name;
    }

    public void NextMessage()
    {
        activeMessage++;
        if (activeMessage < currentMessages.Length)
        {
            DisplayMessage();
        }
        else
        {
            Debug.Log("Dialogue Ended!");
            dialogueGroup.LeanAlpha(0, 0.25f);
            isActive = false;
        }
    }

    void Start()
    {
        dialogueGroup = GetComponent<CanvasGroup>();
        dialogueGroup.alpha = 0;
    }

    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isActive == true)
        {
            NextMessage();
        }

    }

}
