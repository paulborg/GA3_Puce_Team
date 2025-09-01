using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Text;
using TMPro;

//public class ImpDialogueManager : MonoBehaviour
//{
//    [SerializeField]
//    GameObject dialoguePanel;

//    [SerializeField]
//    TextMeshProUGUI dialogueText;

//    [SerializeField]
//    GameObject buttonPrefab;

//    [SerializeField]
//    Transform buttonsParent;

//    [SerializeField]
//    //PlayerController (for interaction, customise to own system)

//    public void BeginDialogue(Dialogue dialogue)
//    {
//        if (dialogue.Choices.Count == 0)
//        {
//            dialoguePanel.SetActive(false);
//            //playerController.ToggleMovement(true);        -- unused, using as reference for own implementation
//            //Cursor.lockState = CursorLockMode.Locked;     -- unused, -^^-
//            //Cursor.visible = false;                       -- unused, -^^-
//            return;
//        }

//        //playerController.ToggleMovement(true);        -- unused, using as reference for own implementation
//        //Cursor.lockState = CursorLockMode.Locked;     -- unused, -^^-
//        //Cursor.visible = false;                       -- unused, -^^-

//        dialoguePanel.SetActive(true);

//        ClearChoices();
//        AnimateText(dialogue);
//    }

    

//    void AnimateText(Dialogue dialogue)   
//    {
//        IEnumerator TypeText(string text)
//        {
//            StringBuilder textToShow = new StringBuilder();

//            for (int i = 0; i < text.Length; i++)
//            {
//                textToShow.Append(text[i]);
//                dialogueText.text = textToShow.ToString();

//                yield return new WaitForSeconds(1f / 20f);
//            }
//            ShowChoices(dialogue);
//        }

//        StartCoroutine(TypeText(dialogue.DialogueText));
//    }

//    void ShowChoices(Dialogue dialogue)
//    {
//        foreach (Dialogue choices in dialogue.Choices)
//        {
//            GameObject newButton = Instantiate(buttonPrefab, buttonsParent);

//            newButton.GetComponentInChildren<TextMeshProUGUI>().text = choices.OptionName;
//            newButton.GetComponent<Button>().onClick.AddListener(() => { BeginDialogue(choices); });
//        }
//    }

//    void ClearChoices()
//    {
//        foreach (Transform child in buttonsParent)
//        {
//            Destroy(child.gameObject);
//        }
//    }
//}


