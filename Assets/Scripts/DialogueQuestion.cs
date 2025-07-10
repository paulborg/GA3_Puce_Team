using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueQuestion : MonoBehaviour
{

    public Transform[] Answers;

    public string text;

    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log(text);

        for (int i = 0; i < Answers.Length; i++)
        {
            Answers[i].gameObject.SetActive(true);
            Debug.Log(Answers[i].name);
        }

    }

}
