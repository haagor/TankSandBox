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
        float delta = Time.fixedDeltaTime;
        float rpmLeft = WheelTrackAlignment(trackLeft);
        foreach (WheelCollider wc in trackLeft.colliders)
        {
            wc.motorTorque = motorLeft;
            ApplyLocalPositionToVisuals(wc, rpmLeft, delta);
        }

        float motorRight = maxMotorTorque * Input.GetAxis("TrackRight");
        float rpmRight = WheelTrackAlignment(trackRight);
        foreach (WheelCollider wc in trackRight.colliders)
        {
            wc.motorTorque = motorRight;
            ApplyLocalPositionToVisuals(wc, rpmRight, delta);
        }
    }

    public void ApplyLocalPositionToVisuals(WheelCollider collider, float rpm, float delta)
    {
        Transform visualWheel = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);
        rpm = Mathf.Repeat(visualWheel.rotation.y + delta * rpm * 360.0f / 60.0f, 360.0f);

        visualWheel.transform.position = position;
        visualWheel.transform.localRotation = Quaternion.Euler(rpm, 0, 0);
    }

    public float WheelTrackAlignment(Track track) {
        float rpm = 0.0f;
        int length = 0;
        foreach (WheelCollider wc in track.colliders) {
            if (wc.isGrounded) {
                rpm += wc.rpm;
                length += 1;
            }
        }
        rpm /= length;
        return rpm;
    }
}