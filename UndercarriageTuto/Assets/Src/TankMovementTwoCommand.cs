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
        float motorLeft = maxMotorTorque * Input.GetAxis("TrackLeft");
        foreach (WheelCollider wc in trackLeft.colliders)
        {
            wc.motorTorque = motorLeft;
            ApplyLocalPositionToVisuals(wc);
        }

        float motorRight = maxMotorTorque * Input.GetAxis("TrackRight");
        foreach (WheelCollider wc in trackRight.colliders)
        {
            wc.motorTorque = motorRight;
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
        visualWheel.transform.rotation = rotation;
    }
}