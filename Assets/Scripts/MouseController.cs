using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseController : MonoBehaviour
{
 
    void Start()
    {
        
    }

    void Update()
    {   
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                var target = hit.transform.GetComponent<InteractionTarget>();
                if (target != null)
                {
                    target.Trigger();
                }
            }
        }
    }
}
