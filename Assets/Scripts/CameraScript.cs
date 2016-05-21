using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraScript : MonoBehaviour {


    public List<GameObject> limits;

    public Transform target;
    
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
        
        float modificator = Input.GetKey(KeyCode.Q)  ? -30 : 30;

        Collider2D obst = Physics2D.OverlapPoint(new Vector2(newPos.x + modificator, newPos.y));
        Collider2D obst2 = Physics2D.OverlapPoint(new Vector2(newPos.x - modificator, newPos.y));
        Collider2D obst3 = Physics2D.OverlapPoint(new Vector2(newPos.x, newPos.y-16));

        Debug.DrawLine(target.transform.position, new Vector2(newPos.x, newPos.y - 16), Color.red, 0.1f);

        if ((obst && obst.tag == "LevelLimit")  || (obst2 && obst2.tag == "LevelLimit"))
        {
            canMove = false;
        }

        if (canMove)
        {
            transform.position = newPos;
        }
        else if (!(obst3 && obst3.tag == "LevelLimit"))
        {
            transform.position = new Vector3(transform.position.x, newPos.y, newPos.z);
        }

	}
}
