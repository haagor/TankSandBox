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
        float delta = Time.fixedDeltaTime;

        float inputTrackLeft = Input.GetAxis("TrackLeft");
        float inputTrackRight = Input.GetAxis("TrackRight");
        //ApplyForwardFriction(trackLeft, trackRight, inputTrackLeft, inputTrackRight);

        WheelColliderBehavior(trackLeft, trackRight, inputTrackLeft, inputTrackRight);

        float rpmLeft = WheelTrackAlignment(trackLeft);
        foreach (WheelCollider wc in trackLeft.colliders)
        {    
            ApplyLocalPositionToVisuals(wc, rpmLeft, delta);
        }

        float rpmRight = WheelTrackAlignment(trackRight);
        foreach (WheelCollider wc in trackRight.colliders)
        {
            ApplyLocalPositionToVisuals(wc, rpmRight, delta);
        }
    }

    public void ApplyLocalPositionToVisuals(WheelCollider collider, float rpm, float delta)
    {
        Transform visualWheel = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        visualWheel.transform.position = position;
        float x = Mathf.Repeat(visualWheel.transform.rotation.y + delta * rpm * 360.0f / 60.0f, 360.0f);
        visualWheel.transform.Rotate(new Vector3(x, 0.0f, 0.0f), Space.Self);
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
        if (length == 0) {
            foreach (WheelCollider wc in track.colliders) {
                rpm += wc.rpm;
                length += 1;
            }
        }

        rpm /= length;
        return rpm;
    }

    public void ApplyForwardFriction(Track trackLeft, Track trackRight, float inputTrackLeft, float inputTrackRight) {
        if (inputTrackLeft == 0.0f & inputTrackRight == 0.0f) {
            foreach (WheelCollider wc in trackLeft.colliders) {
                WheelFrictionCurve fc = wc.forwardFriction;
                fc.stiffness = 10;
                wc.forwardFriction = fc;
            }
            foreach (WheelCollider wc in trackRight.colliders) {
                WheelFrictionCurve fc = wc.forwardFriction;
                fc.stiffness = 10;
                wc.forwardFriction = fc;
            }
        }
    }

    public void WheelColliderBehavior(Track trackLeft, Track trackRight, float inputTrackLeft, float inputTrackRight) {
        float motorLeft = maxMotorTorque * inputTrackLeft;
        float motorRight = maxMotorTorque * inputTrackRight;
        float rpmLeft = WheelTrackAlignment(trackLeft);
        float rpmRight = WheelTrackAlignment(trackRight);

        foreach (WheelCollider wc in trackLeft.colliders) {
            if (motorLeft == 0.0f && motorRight == 0.0f) {
                wc.brakeTorque = 1000.0f;
            } else {
                wc.brakeTorque = 0.0f;
                wc.motorTorque = motorLeft;
            }
        }

        foreach (WheelCollider wc in trackRight.colliders) {
            if (motorRight == 0.0f && motorLeft == 0.0f) {
                wc.brakeTorque = 1000.0f;
            } else {
                wc.brakeTorque = 0.0f;
                wc.motorTorque = motorRight;
            }
        }
    }
}