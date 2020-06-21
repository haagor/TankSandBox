using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTrack : MonoBehaviour {
    public GameObject link;
    public GameObject[] links;

    void Start() {

        GameObject linkClone;
        linkClone = Instantiate(link);
        links[0] = linkClone;
        for (int i = 1; i < links.Length; i++) {
            linkClone = Instantiate(link);
            linkClone.transform.TransformPoint(new Vector3(2*i,0,0));
            linkClone.AddComponent<HingeJoint>();
            linkClone.GetComponent<HingeJoint>().connectedBody=links[i-1].GetComponent<Rigidbody>();
            links[i] = linkClone;
        }
    }

    void Update() {
        
    }
}
