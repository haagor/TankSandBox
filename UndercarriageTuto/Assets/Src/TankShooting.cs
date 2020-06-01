using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Track
{
    public List<WheelCollider> colliders;
}

public class TankMovementTwoCommand : MonoBehaviour
{
    public Track trackLeft;
    public Track trackRight;
    public float maxMotorTorque;

    public void FixedUpdate()
    {
        float motor = maxMotorTorque * Input.GetAxis("Vertical");

        foreach (WheelCollider wc in trackLeft.colliders)
        {
            wc.motorTorque = motor;
            ApplyLocalPositionToVisuals(wc);
        }
        foreach (WheelCollider wc in trackRight.colliders)
        {
            wc.motorTorque = motor;
            ApplyLocalPositionToVisuals(wc);
        }
    }

    public void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        Transform visualWheel = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        visualWheel.transform.position = position;
    }
}