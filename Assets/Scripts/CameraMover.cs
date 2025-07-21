using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    //vvv_Part of crosshair misalignment fix_vvv
    public RectTransform crosshairUI;

    //public float swayDistance = 50f;

    private Vector2 screenCenter;
    public float swayToPixelScaleX = 50f;
    public float swayToPixelScaleY = 30f;

    private Canvas parentCanvas;

    void Start()
    {
        camTargetPos = null;
        camCurrentPos = transform.position;
        initialRotation = transform.localRotation;

        //vvv_Part of crosshair misalignment fix_vvv
        Cursor.visible = false;
        screenCenter = new Vector2(Screen.width / 2F, Screen.height / 2f);
        parentCanvas = crosshairUI.GetComponentInParent<Canvas>();
    }

    void Update()
    {
        UpdateMouseSway();
        UpdateCustomCursorPosition(); //Part of crosshair misalignment fix
        //UpdateCrosshairPosition(); //Part of crosshair misalignment fix

        //Camera Movement
        if (camTargetPos != null)
        {
            transform.position = Vector3.MoveTowards(camCurrentPos, camTargetPos.position, 5f * Time.deltaTime);
            camCurrentPos = transform.position;
        }

        #region //Early Cam Movement       
        /* -- Thought I'd have to reset the target position once arriving at it, for some reason... 
        So tried to do this but kept getting "Object reference not set to an instance of an Object" error"
        Turns out it wasn't needed, and the camTargetPos could stay filled and would just get replaced by
        the new target when clicking on the next interactable.
        */

        //if (camCurrentPos == camTargetPos.position)
        //{
        //    camTargetPos = null;

        //}

        else if (camTargetPos != null && camTargetPos.position == transform.position)
        {
            camTargetPos = null;
            camCurrentPos = transform.position;
        }
        #endregion
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

        #region //Crosshair Misalignment Fix Attempt (#2?)
        //float swayOffsetX = normalizedX * swayToPixelScaleX;
        //float swayOffsetY = normalizedX * swayToPixelScaleY;

        //crosshairUI.anchoredPosition = new Vector2(swayOffsetX, swayOffsetY);
        #endregion
        #region Crosshair Misalignment Fix Attempt (#3?)
        //Vector3 forwardTarget = transform.position + transform.forward * 10f;
        //Vector3 screenPoint = Camera.main.WorldToScreenPoint(forwardTarget);

        //RectTransform canvasRect = parentCanvas.GetComponent<RectTransform>();
        //Vector2 localPos;
        //RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, screenPoint, null, out localPos);
        //crosshairUI.anchoredPosition = localPos;
        #endregion
    }

    void UpdateCustomCursorPosition()
    {
        Vector2 screenPos = Input.mousePosition;

        RectTransform canvasRect = parentCanvas.GetComponent<RectTransform>();
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, screenPos, null, out localPoint);

        crosshairUI.anchoredPosition = localPoint;
    }

    private void OnGUI()
    {
        Vector2 pos = crosshairUI.position;
        GUI.Label(new Rect(pos.x, Screen.height - pos.y, 200, 40), "•");
    }

    //void UpdateCrosshairPosition()
    //{
    //    Vector2 mouse = Input.mousePosition;
    //    float normalizedX = (mouse.x / Screen.width - 0.5f) * 2f;
    //    float normalizedY = (mouse.y / Screen.height - 0.5f) * 2f;

    //    Vector2 swayOffset = new Vector2(normalizedX, normalizedY) * swayDistance;
    //    crosshairUI.anchoredPosition = swayOffset;
    //}

}
