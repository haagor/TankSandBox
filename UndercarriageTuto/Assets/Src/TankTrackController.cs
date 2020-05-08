using UnityEngine;
using System.Collections;
using System.Collections.Generic; //1

public class TankTrackController : MonoBehaviour
{

    public GameObject wheelCollider; //2

    public float wheelRadius = 0.15f; //3
    public float suspensionOffset = 0.05f; //4

    public float trackTextureSpeed = 2.5f; //5

    public GameObject leftTrack;  //6
    public Transform[] leftTrackUpperWheels; //7
    public Transform[] leftTrackWheels; //8
    public Transform[] leftTrackBones; //9

    public GameObject rightTrack; //6
    public Transform[] rightTrackUpperWheels; //7
    public Transform[] rightTrackWheels; //8
    public Transform[] rightTrackBones; //9

    public class WheelData
    { //10
        public Transform wheelTransform; //11
        public Transform boneTransform; //12
        public WheelCollider col; //13
        public Vector3 wheelStartPos; //14
        public Vector3 boneStartPos; //15
        public float rotation = 0.0f; //16
        public Quaternion startWheelAngle;  //17
    }

    protected WheelData[] leftTrackWheelData; //18
    protected WheelData[] rightTrackWheelData; //18

    protected float leftTrackTextureOffset = 0.0f; //19
    protected float rightTrackTextureOffset = 0.0f; //19

    void Awake()
    {

        leftTrackWheelData = new WheelData[leftTrackWheels.Length]; //1 
        rightTrackWheelData = new WheelData[rightTrackWheels.Length]; //1 

        for (int i = 0; i < leftTrackWheels.Length; i++)
        {
            leftTrackWheelData[i] = SetupWheels(leftTrackWheels[i], leftTrackBones[i]);  //2 
        }

        for (int i = 0; i < rightTrackWheels.Length; i++)
        {
            rightTrackWheelData[i] = SetupWheels(rightTrackWheels[i], rightTrackBones[i]); //2  
        }

        Vector3 offset = transform.position; //3 
        offset.z += 0.01f;  //3 
        transform.position = offset; //3		 

    }


    WheelData SetupWheels(Transform wheel, Transform bone)
    {  //2 
        WheelData result = new WheelData();

        GameObject go = new GameObject("Collider_" + wheel.name); //4
        go.transform.parent = transform; //5 	
        go.transform.position = wheel.position; //6
        go.transform.localRotation = Quaternion.Euler(0, wheel.localRotation.y, 0); //7 

        WheelCollider col = (WheelCollider)go.AddComponent(typeof(WheelCollider));//8 
        WheelCollider colPref = wheelCollider.GetComponent<WheelCollider>();//9 

        col.mass = colPref.mass;//10
        col.center = colPref.center;//10
        col.radius = colPref.radius;//10
        col.suspensionDistance = colPref.suspensionDistance;//10
        col.suspensionSpring = colPref.suspensionSpring;//10
        col.forwardFriction = colPref.forwardFriction;//10
        col.sidewaysFriction = colPref.sidewaysFriction;//10 

        result.wheelTransform = wheel; //11
        result.boneTransform = bone; //11
        result.col = col; //11
        result.wheelStartPos = wheel.transform.localPosition; //11
        result.boneStartPos = bone.transform.localPosition; //11
        result.startWheelAngle = wheel.transform.localRotation; //11

        return result; //12
    }

}