using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraAction : MonoBehaviour
{
    public Transform moveTarget;

    public void Execute()
    {
        Camera.main.GetComponent<CameraMover>().SetTarget(moveTarget);
    }


}
