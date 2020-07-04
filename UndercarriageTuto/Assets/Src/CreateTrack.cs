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
            linkClone = Instantiate(link, new Vector3(2*i,0,0), Quaternion.identity);
            linkClone.AddComponent<HingeJoint>();
            linkClone.GetComponent<HingeJoint>().connectedBody=links[i-1].GetComponent<Rigidbody>();
            linkClone.GetComponent<HingeJoint>().autoConfigureConnectedAnchor = false;
            linkClone.GetComponent<HingeJoint>().connectedAnchor = new Vector3(2,0,0);
            linkClone.GetComponent<HingeJoint>().axis = new Vector3(0,0,1);
            links[i] = linkClone;
        }
    }
}
