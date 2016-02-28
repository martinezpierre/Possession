using UnityEngine;
using System.Collections;

public class PNJ : Controlable {

    // Use this for initialization
    protected override void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void Move()
    {
        base.Move();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //transform.position = new Vector3(transform.position.x, transform.position.y + .5f, transform.position.z);
            rb.AddForce(new Vector2(0, 12), ForceMode2D.Impulse);
        }
        else
        {
            //transform.position = new Vector3(transform.position.x, transform.position.y - .25f, transform.position.z);
        }
    }
}
