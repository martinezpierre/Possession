using UnityEngine;
using System.Collections;

public class BigPNJ : PNJ {

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        gameObject.layer = 0;
        GetComponent<Rigidbody2D>().mass = 1000000;
    }

    // Update is called once per frame
    void Update () {
	
	}

    public override void TakeControl(bool b)
    {
        base.TakeControl(b);

        gameObject.layer = b ? 8 : 0;
        GetComponent<Rigidbody2D>().mass = b ? 1 : 1000000;

        int modifier = b ? 1 : -1;

        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + modifier, transform.localScale.z);
    }
}
