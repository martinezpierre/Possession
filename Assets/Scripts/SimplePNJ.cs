using UnityEngine;
using System.Collections;

public class SimplePNJ : PNJ {

    GameObject inHand = null;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.E) && inHand)
        {
            Throw();
        }
	}

    public void Take(GameObject gO)
    {
        Debug.Log("take");
        inHand = gO;

        inHand.GetComponent<Rigidbody2D>().isKinematic = true;

        inHand.transform.parent = transform;
        inHand.transform.localPosition = Vector3.zero;
    }

    public void Throw()
    {
        Debug.Log("throw");

        inHand.GetComponent<Rigidbody2D>().isKinematic = false;

        inHand.transform.parent = null;
        
        Vector2 force = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;

        inHand.GetComponent<Rigidbody2D>().AddForce(force*100, ForceMode2D.Impulse);

        inHand = null;
    }
}
