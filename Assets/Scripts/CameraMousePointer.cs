using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraMousePointer : MonoBehaviour
{
    public Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        RaycastHit hitInfo;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
        {
            #region Raycast Debug
            Debug.DrawRay(ray.origin, ray.direction * 100 - ray.origin, Color.red);     //Ray that goes through colliders
                                                                                        //Debug.DrawRay(ray.origin, hitInfo.point - ray.origin, Color.red);        //Ray that stops when hitting colliders
                                                                                        //Debug.Log("Pointer hitting " + hitInfo.transform);                       //Debug text to check what transform the ray is hitting
            #endregion

            if (hitInfo.transform.CompareTag("Interact") && Input.GetMouseButton(0))
            {
                Debug.Log("Interact found: " + hitInfo.transform);

                //hitInfo.transform.GetComponent<MeshRenderer>().material.SetColor("_BaseColor", Color.red);
                //hitInfo.transform.GetComponent<InteractSelector>().Selected(true);

                mainCamera.GetComponent<CameraMover>().camTargetPos = hitInfo.transform;   
            }



        }
    }
}
