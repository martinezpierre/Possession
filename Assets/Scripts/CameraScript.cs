using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraScript : MonoBehaviour {


    public List<GameObject> limits;

    public Transform target;

    Vector3 lastTargetPos;

    Vector3 addi;

	// Use this for initialization
	void Start () {
	    foreach(GameObject go in GameObject.FindGameObjectsWithTag("LevelLimit"))
        {
            limits.Add(go);
        }
        
        addi = target.position - transform.position;

	}
	
	// Update is called once per frame
	void Update () {

        Vector3 newPos = target.position - addi;

        bool canMove = true;
        
        float direction = (target.position - lastTargetPos).x;
        
        float modificator = direction > 0 ? 30 : -30;

        Collider2D obst = Physics2D.OverlapPoint(new Vector2(newPos.x + modificator, newPos.y));

        if (obst && obst.tag == "LevelLimit")
        {
            canMove = false;
        }

        if (canMove)
        {
            lastTargetPos = transform.position;
            transform.position = newPos;
        }

	}
}
