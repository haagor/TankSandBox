using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearControl : MonoBehaviour
{

    public Rigidbody gearAxe;
    private float z = 0.0f;

    void Update()
    {
        if (Input.GetKey("up"))
        {
            z += 0.3f;
        }
        if (Input.GetKey("down"))
        {
            z -= 0.3f;
        }
        gearAxe.MoveRotation(Quaternion.Euler(0,0,z));
    }
}
