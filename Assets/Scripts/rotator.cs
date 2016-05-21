using UnityEngine;
using System.Collections;

public class rotator : MonoBehaviour {

    Transform target;

    // Use this for initialization
    void Start () {
        target = FindObjectOfType<PlayerController>().transform;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = target.position;
        transform.Rotate(new Vector3(0, 0, 10));
	}
}
