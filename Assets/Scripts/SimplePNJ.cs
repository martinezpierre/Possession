using UnityEngine;
using System.Collections;

public class SimplePNJ : PNJ {

    GameObject inHand = null;

    bool oQP = false;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (Input.GetKeyUp(KeyCode.E) && inHand)
        {
            Throw();
        }

        oQP = false;
    }

    public void Take(GameObject gO)
    {
        if (oQP) return;

        Debug.Log("take");
        inHand = gO;

        inHand.GetComponent<Rigidbody2D>().isKinematic = true;

        inHand.GetComponent<LittlePNJ>().enabled = false;

        inHand.transform.parent = transform;
        inHand.transform.localPosition = Vector3.zero;

        inHand.GetComponent<Controlable>().usable = false;

        oQP = true;
    }

    public void Throw()
    {
        if (oQP) return;

        Debug.Log("throw");
        
        inHand.GetComponent<Controlable>().usable = true;

        inHand.GetComponent<Rigidbody2D>().isKinematic = false;

        inHand.GetComponent<LittlePNJ>().enabled = true;

        inHand.transform.parent = null;
        
        Vector2 force = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;

        inHand.GetComponent<Rigidbody2D>().AddForce(force*80, ForceMode2D.Impulse);

        inHand = null;

        oQP = true;
    }
}
