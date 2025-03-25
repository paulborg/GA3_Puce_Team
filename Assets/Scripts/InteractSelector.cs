using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractSelector : MonoBehaviour
{
    public GameObject InteractInput;
    public bool isSelected;

    void Start()
    {
        
    }
    
    void Update()
    {
        if (GetComponent<MeshRenderer>().material.GetColor("_BaseColor") != Color.white)
        {
            GetComponent<MeshRenderer>().material.SetColor("_BaseColor", Color.white);
        }
    }

    public void Selected(bool isSelected)
    {
        if (isSelected)
        {
            GetComponent<MeshRenderer>().material.SetColor("_BaseColor", Color.red);
        }

    }

}
