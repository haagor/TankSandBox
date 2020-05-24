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

    public AudioSource track;
    public Engine engine;
    public EngineHUD engineHUD;

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
        Destroy(wheelCollider);
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

    public float rotateOnStandTorque = 1500.0f; //1
    public float rotateOnStandBrakeTorque = 500.0f; //2
    public float maxBrakeTorque = 1000.0f; //3

    void FixedUpdate()
    {
        engine.CheckActionEngine(engineHUD);
        float accelerate = 0;
        float steer = 0;
        if (engine.IsEngineOn())
        {
            accelerate = Input.GetAxis("Vertical");  //4
            steer = Input.GetAxis("Horizontal"); //4
        }
        WheelsSound(accelerate, steer);
        UpdateWheels(accelerate, steer); //5 
    }

    public void WheelsSound(float accelerate, float steer)
    {
        if (accelerate != 0 | steer != 0)
        {
            if (!track.isPlaying)
            {
                track.Play();
            }
        }
        else
        {
            track.Stop();
        }
    }


    public void UpdateWheels(float accel, float steer)
    { //5
        float delta = Time.fixedDeltaTime;

        float trackRpm = CalculateSmoothRpm(leftTrackWheelData);

        foreach (WheelData w in leftTrackWheelData)
        {
            w.wheelTransform.localPosition = CalculateWheelPosition(w.wheelTransform, w.col, w.wheelStartPos);
            w.boneTransform.localPosition = CalculateWheelPosition(w.boneTransform, w.col, w.boneStartPos);

            w.rotation = Mathf.Repeat(w.rotation + delta * trackRpm * 360.0f / 60.0f, 360.0f);
            w.wheelTransform.localRotation = Quaternion.Euler(w.rotation, w.startWheelAngle.y, w.startWheelAngle.z);

            CalculateMotorForce(w.col, accel, steer);  //6 
        }


        leftTrackTextureOffset = Mathf.Repeat(leftTrackTextureOffset + delta * trackRpm * trackTextureSpeed / 60.0f, 1.0f);
        leftTrack.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(0, -leftTrackTextureOffset));

        trackRpm = CalculateSmoothRpm(rightTrackWheelData);

        foreach (WheelData w in rightTrackWheelData)
        {
            w.wheelTransform.localPosition = CalculateWheelPosition(w.wheelTransform, w.col, w.wheelStartPos);
            w.boneTransform.localPosition = CalculateWheelPosition(w.boneTransform, w.col, w.boneStartPos);

            w.rotation = Mathf.Repeat(w.rotation + delta * trackRpm * 360.0f / 60.0f, 360.0f);
            w.wheelTransform.localRotation = Quaternion.Euler(w.rotation, w.startWheelAngle.y, w.startWheelAngle.z);

            CalculateMotorForce(w.col, accel, -steer); //6 
        }

        rightTrackTextureOffset = Mathf.Repeat(rightTrackTextureOffset + delta * trackRpm * trackTextureSpeed / 60.0f, 1.0f);
        rightTrack.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(0, -rightTrackTextureOffset));

        for (int i = 0; i < leftTrackUpperWheels.Length; i++)
        {
            leftTrackUpperWheels[i].localRotation = Quaternion.Euler(leftTrackWheelData[0].rotation, leftTrackWheelData[0].startWheelAngle.y, leftTrackWheelData[0].startWheelAngle.z);
        }

        for (int i = 0; i < rightTrackUpperWheels.Length; i++)
        {
            rightTrackUpperWheels[i].localRotation = Quaternion.Euler(rightTrackWheelData[0].rotation, rightTrackWheelData[0].startWheelAngle.y, rightTrackWheelData[0].startWheelAngle.z);
        }
    }

    public float forwardTorque = 500.0f; //1
    public float rotateOnMoveBrakeTorque = 400.0f; //2 
    public float minBrakeTorque = 0.0f; //3 
    public float minOnStayStiffness = 0.06f; //4 
    public float minOnMoveStiffness = 0.05f;  //5 
    public float rotateOnMoveMultiply = 1.0f; //6

    public void CalculateMotorForce(WheelCollider col, float accel, float steer)
    {
        WheelFrictionCurve fc = col.sidewaysFriction;  //7 

        if (accel == 0 && steer == 0)
        {
            col.brakeTorque = maxBrakeTorque;
        }
        else if (accel == 0.0f)
        {
            col.brakeTorque = rotateOnStandBrakeTorque;
            col.motorTorque = steer * rotateOnStandTorque;
            fc.stiffness = 1.0f + minOnStayStiffness - Mathf.Abs(steer);

        }
        else
        { //8 

            col.brakeTorque = minBrakeTorque;  //9 
            col.motorTorque = accel * forwardTorque;  //10 

            if (steer < 0)
            { //11 
                col.brakeTorque = rotateOnMoveBrakeTorque; //12 
                col.motorTorque = steer * forwardTorque * rotateOnMoveMultiply;//13 
                fc.stiffness = 1.0f + minOnMoveStiffness - Mathf.Abs(steer);  //14 
            }

            if (steer > 0)
            { //15 

                col.motorTorque = steer * forwardTorque * rotateOnMoveMultiply;//16 
                fc.stiffness = 1.0f + minOnMoveStiffness - Mathf.Abs(steer); //17
            }


        }

        if (fc.stiffness > 1.0f) fc.stiffness = 1.0f; //18		 
        col.sidewaysFriction = fc; //19

        if (col.rpm > 0 && accel < 0)
        { //20 
            col.brakeTorque = maxBrakeTorque;  //21
        }
        else if (col.rpm < 0 && accel > 0)
        { //22 
            col.brakeTorque = maxBrakeTorque; //23
        }
    }

    private float CalculateSmoothRpm(WheelData[] w)
    { //12 
        float rpm = 0.0f;

        List<int> grWheelsInd = new List<int>(); //13 

        for (int i = 0; i < w.Length; i++)
        { //14 
            if (w[i].col.isGrounded)
            {  //14 
                grWheelsInd.Add(i); //14 
            }
        }

        if (grWheelsInd.Count == 0)
        {  //15   
            foreach (WheelData wd in w)
            {  //15 
                rpm += wd.col.rpm;  //15				 
            }

            rpm /= w.Length; //15 

        }
        else
        {  //16 

            for (int i = 0; i < grWheelsInd.Count; i++)
            {  //16 
                rpm += w[grWheelsInd[i]].col.rpm; //16	 
            }

            rpm /= grWheelsInd.Count; //16 
        }

        return rpm; //17 
    }


    private Vector3 CalculateWheelPosition(Transform w, WheelCollider col, Vector3 startPos)
    {  //18 
        WheelHit hit;

        Vector3 lp = w.localPosition;
        if (col.GetGroundHit(out hit))
        {
            lp.y -= Vector3.Dot(w.position - hit.point, transform.up) - wheelRadius;

        }
        else
        {
            lp.y = startPos.y - suspensionOffset;

        }

        return lp;
    }

}