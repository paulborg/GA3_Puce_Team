using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public Transform camTargetPos;
    private Vector3 camCurrentPos;
    //public int targetPoint;


    void Start()
    {
        camTargetPos = null;
        camCurrentPos = transform.position;
    }


    void Update()
    {
        if (camTargetPos != null)
        {
            transform.position = Vector3.MoveTowards(camCurrentPos, camTargetPos.position, 5f * Time.deltaTime);
            camCurrentPos = transform.position;

        }


        /* -- Thought I'd have to reset the target position once arriving at it, for some reason... 
        So tried to do this but kept getting "Object reference not set to an instance of an Object" error"
        Turns out it wasn't needed, and the camTargetPos could stay filled and would just get replaced by
        the new target when clicking on the next interactable.
        */

        //if (camCurrentPos == camTargetPos.position)
        //{
        //    camTargetPos = null;

        //}

        //else if (camTargetPos != null && camTargetPos.position == transform.position)
        //{ 
        //    camTargetPos = null;
        //    //camCurrentPos = transform.position;
        //}
    }

}
