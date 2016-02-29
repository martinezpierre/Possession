using UnityEngine;
using System.Collections;

public class Controlable : MonoBehaviour {

    PlayerController pC;
    public bool usable = true;
    protected Rigidbody2D rb;

	// Use this for initialization
	protected virtual void Start () {
        pC = FindObjectOfType<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnMouseDown()
    {
        if (usable && Vector2.Distance(transform.position,pC.transform.position) < 12f)
        {
            TakeControl(true);
            pC.ChangeBody(transform);
        }
    }

   bool[] CheckCollision()
    {
        bool[] b = new bool[2];
        
        Vector3 right = transform.right;

        Vector3 left = -right;

        float range = transform.lossyScale.x + 0.5f;

        /*Debug.DrawLine(transform.position, transform.position + right * range, Color.red, 100);
        Debug.DrawLine(transform.position, transform.position + left * range, Color.red, 100);*/

        RaycastHit2D hit = Physics2D.Raycast(transform.position, right, range);
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position, left, range);
        
        b[0] = Physics2D.Raycast(transform.position, right, range) && hit.transform.tag == "Obstacle";
        
        b[1] = Physics2D.Raycast(transform.position, left, range) && hit2.transform.tag == "Obstacle";

        return b;
    }

    public virtual void Move()
    {
        bool[] collisions = CheckCollision();

        Debug.Log(collisions[0] + " " + collisions[1]);

        if (Input.GetKey(KeyCode.Q) && !collisions[1])
        {
            //transform.position = new Vector3(transform.position.x - .1f, transform.position.y, transform.position.z);
            transform.Translate(-transform.right / 10);
        }
        else if (Input.GetKey(KeyCode.D) && !collisions[0])
        {
            //transform.position = new Vector3(transform.position.x + .1f, transform.position.y, transform.position.z);
            transform.Translate(transform.right / 10);
        }
    }

    public virtual void TakeControl(bool b)
    {
        usable = !b;
    }
}
