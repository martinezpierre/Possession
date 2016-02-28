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

    public virtual void Move()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            //transform.position = new Vector3(transform.position.x - .1f, transform.position.y, transform.position.z);
            transform.Translate(-transform.right / 10);
        }
        else if (Input.GetKey(KeyCode.D))
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
