using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMousePointer : MonoBehaviour
{

    void Start()
    {

    }


    void Update()
    {
        RaycastHit hitInfo;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
        {
            Debug.DrawRay(ray.origin, hitInfo.point - ray.origin, Color.red);
            //Debug.Log("Pointer hitting " + hitInfo.transform);
            //Debug.DrawRay(ray.origin, ray.direction * Mathf.Infinity - ray.origin, Color.red);

            if (hitInfo.transform.CompareTag("Interact"))
            {
                Debug.Log("Interact found: " + hitInfo.transform);
                hitInfo.transform.GetComponent<MeshRenderer>().material.SetColor("_BaseColor", Color.red);
            }


        }
    }
}
