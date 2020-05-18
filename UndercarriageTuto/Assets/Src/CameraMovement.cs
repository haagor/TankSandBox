using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject turret_pivot;
    public GameObject canon_pivot;
    public float sensitivity;

    private float canon_pivot_rotation;

    void FixedUpdate()
    {
        float rotateHorizontal = Input.GetAxis("Mouse X");
        turret_pivot.transform.Rotate(
            0,
            rotateHorizontal * sensitivity,
            0);

        float rotateVertical = Input.GetAxis("Mouse Y");
        canon_pivot_rotation += Input.GetAxis("Mouse Y") * sensitivity;
        Debug.Log(canon_pivot_rotation);
        if (canon_pivot_rotation < 30 && canon_pivot_rotation > -20)
        {
            canon_pivot.transform.Rotate(
                0,
                rotateVertical * sensitivity,
                0);
        }
    }
}