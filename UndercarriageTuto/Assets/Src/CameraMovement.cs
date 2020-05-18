using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject turret_pivot;
    public GameObject canon_pivot;
    public float sensitivity;

    void FixedUpdate()
    {
        float rotateHorizontal = Input.GetAxis("Mouse X");
        turret_pivot.transform.Rotate(
            0,
            rotateHorizontal * sensitivity,
            0);

        float rotateVertical = Input.GetAxis("Mouse Y");
        rotateVertical = Mathf.Clamp(rotateVertical, 70, 100);
        canon_pivot.transform.Rotate(
            0,
            rotateVertical * sensitivity,
            0);
    }
}