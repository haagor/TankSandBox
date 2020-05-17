using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject turret_pivot;
    public float sensitivity;

    void FixedUpdate()
    {
        float rotateHorizontal = Input.GetAxis("Mouse X");
        turret_pivot.transform.Rotate(
            0,
            rotateHorizontal * sensitivity,
            0);
    }
}
