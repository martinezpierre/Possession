using UnityEngine;
using System.Collections;

public class LittlePNJ : Controlable
{

    bool canMoveUp = false;

    bool canBeTaken = false;
    SimplePNJ taker = null;

    public GameObject EObject;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();

        EObject.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
        if (canBeTaken && Input.GetKeyDown(KeyCode.E))
        {
            taker.Take(gameObject);
        }
    }

    public void SetCanMoveUp(bool b)
    {
        canMoveUp = b;
        GetComponent<Rigidbody2D>().gravityScale = canMoveUp ? 0 : 1;
    }

    public override void Move()
    {
        base.Move();

        if (canMoveUp)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                //transform.position = new Vector3(transform.position.x - .1f, transform.position.y, transform.position.z);
                transform.Translate(transform.up / 10);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                //transform.position = new Vector3(transform.position.x + .1f, transform.position.y, transform.position.z);
                transform.Translate(-transform.up / 10);
            }
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PNJSimple" && usable)
        {
            canBeTaken = true;
            taker = other.GetComponent<SimplePNJ>();
            EObject.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        canBeTaken = false;
        taker = null;
        EObject.SetActive(false);
    }
}
