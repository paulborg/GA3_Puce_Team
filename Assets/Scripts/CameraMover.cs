using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public Transform camTargetPos;
    private Vector3 camCurrentPos;
    //public int targetPoint;

    [Header("Mouse Sway Settings")]
    public float maxAngleX = 5f;
    public float maxAngleY = 10f;
    public float swaySmoothSpeed = 5f;

    private Quaternion initialRotation;

    void Start()
    {
        camTargetPos = null;
        camCurrentPos = transform.position;
        initialRotation = transform.localRotation;
    }

    void Update()
    {
        UpdateMouseSway();





        // Camera Movement
        /*if (camTargetPos != null)
        {
            transform.position = Vector3.MoveTowards(camCurrentPos, camTargetPos.position, 5f * Time.deltaTime);
            camCurrentPos = transform.position;
        }
        */
        //Mouse Sway Effect



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

    void UpdateMouseSway()
    {
        Vector2 screenPos = Input.mousePosition;
        float normalizedX = (screenPos.x / Screen.width - 0.5f) * 2f;
        float normalizedY = (screenPos.y / Screen.height - 0.5f) * 2f;

        float targetX = -normalizedY * maxAngleX;
        float targetY = normalizedX * maxAngleY;

        Quaternion targetRotation = initialRotation * Quaternion.Euler(targetX, targetY, 0f);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, Time.deltaTime * swaySmoothSpeed);
    }

}
