using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class DialogueController : MonoBehaviour
{
    public static DialogueController Instance { get; private set; } //Singleton

    public GameObject dialoguePanel;
    public TMP_Text dialogueText, nameText;
    public Transform buttonsPanel;
    public GameObject buttonPrefab;


    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
  
    public void ShowDialogueUI(bool show)
    {
        dialoguePanel.SetActive(show);
    }
    
    public void SetCharInfo(string charName)
    {
        nameText.text = charName;
    }

    public void SetDialogueText(string text)
    {
        dialogueText.text = text;
    }

    public void ClearChoices()
    {
        foreach (Transform child in buttonsPanel) Destroy(child.gameObject);
    }

    public GameObject CreateChoiceButton(string choiceText, UnityEngine.Events.UnityAction onClick)
    {
        GameObject choiceButton = Instantiate(buttonPrefab, buttonsPanel);
        choiceButton.GetComponentInChildren<TMP_Text>().text = choiceText;
        choiceButton.GetComponent<Button>().onClick.AddListener(onClick);
        return choiceButton;
    }

}
