using UnityEngine;
using System.Collections;

public class Controlable : MonoBehaviour
{
    public SpriteRenderer Body;

    protected PlayerController pC;
    public bool usable = true;
    protected Rigidbody2D rb;

    protected float distToGround;

    protected bool jumping;

    protected bool canFall;

    protected bool isFalling;

    protected Animator aC;

    protected float scaleX;

    protected bool isMooving;

    [HideInInspector]public Switch switchObject;

    // Use this for initialization
    protected virtual void Start()
    {
        scaleX = Body.transform.localScale.x;

        pC = FindObjectOfType<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
        aC = GetComponentInChildren<Animator>();

        distToGround = GetComponent<Collider2D>().bounds.extents.y;

        jumping = false;
        canFall = true;
        isFalling = false;

        GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (!IsGrounded() && !jumping)
        {
            if (canFall)
            {
                isFalling = true;
                transform.Translate(-transform.up / 5);
            }
        }
        else if(IsGrounded())
        {
            jumping = false;
            isFalling = false;
        }
    }

    void OnMouseDown()
    {
        if (usable && Vector2.Distance(transform.position, pC.transform.position) < 12f)
        {
            TakeControl(true);
            pC.ChangeBody(transform);
        }
    }

    bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
        RaycastHit2D hit2 = Physics2D.Raycast(new Vector3(transform.position.x + GetComponent<Collider2D>().bounds.extents.x,transform.position.y,transform.position.z), -Vector3.up, distToGround + 0.1f);
        RaycastHit2D hit3 = Physics2D.Raycast(new Vector3(transform.position.x - GetComponent<Collider2D>().bounds.extents.x, transform.position.y, transform.position.z), -Vector3.up, distToGround + 0.1f);

        /*if (hit)
        {
            Debug.Log(hit.transform.tag);
        }*/

        return (hit && hit.transform.tag == "Obstacle") || (hit2 && hit2.transform.tag == "Obstacle") || (hit3 && hit3.transform.tag == "Obstacle");
    }

    bool[] CheckCollision()
    {
        bool[] b = new bool[2];

        Vector3 right = transform.right;

        Vector3 left = -right;

        float range = GetComponent<BoxCollider2D>().bounds.extents.x + 0.1f;

        /*Debug.DrawLine(transform.position, transform.position + right * range, Color.red, 100);
        Debug.DrawLine(transform.position, transform.position + left * range, Color.red, 100);*/

        RaycastHit2D hit = Physics2D.Raycast(transform.position, right, range);
        RaycastHit2D hit2 = Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y - GetComponent<Collider2D>().bounds.extents.y , transform.position.z), right, range);
        RaycastHit2D hit3 = Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y + GetComponent<Collider2D>().bounds.extents.y, transform.position.z), right, range);

        RaycastHit2D hitRear = Physics2D.Raycast(transform.position, left, range);
        RaycastHit2D hitRear2 = Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y - GetComponent<Collider2D>().bounds.extents.y, transform.position.z), left, range);
        RaycastHit2D hitRear3 = Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y + GetComponent<Collider2D>().bounds.extents.y, transform.position.z), left, range);

        b[0] = (hit && hit.transform.tag == "Obstacle") || (hit2 && hit2.transform.tag == "Obstacle") || (hit3 && hit3.transform.tag == "Obstacle");

        b[1] = (hitRear && hitRear.transform.tag == "Obstacle") || (hitRear2 && hitRear2.transform.tag == "Obstacle") || (hitRear3 && hitRear3.transform.tag == "Obstacle");

        return b;
    }

    public virtual void Move()
    {
        bool[] collisions = CheckCollision();
        
        if (Input.GetKey(KeyCode.Q) && !collisions[1])
        {
            if (aC) aC.SetBool("isWalking",true);
            transform.Translate(-transform.right / 7);
            if(Body.transform.localScale.x > 0) Body.transform.localScale = new Vector3(-Body.transform.localScale.x, Body.transform.localScale.y, Body.transform.localScale.z);
            //Body.transform.localScale = new Vector3(-scaleX, Body.transform.localScale.y, Body.transform.localScale.z);
            isMooving = true;
        }
        else if (Input.GetKey(KeyCode.D) && !collisions[0])
        {
            if (aC) aC.SetBool("isWalking", true);
            transform.Translate(transform.right / 7);
            if (Body.transform.localScale.x < 0) Body.transform.localScale = new Vector3(-Body.transform.localScale.x, Body.transform.localScale.y, Body.transform.localScale.z);
            //Body.transform.localScale = new Vector3(scaleX, Body.transform.localScale.y, Body.transform.localScale.z);
            isMooving = true;
        }
        else
        {
            if (aC) aC.SetBool("isWalking", false);
            isMooving = false;
        }
    }

    public virtual void TakeControl(bool b)
    {
        usable = !b;

        if (!b)
        {
            Body.color = Color.white;
        }

        if (switchObject)
        {
            if (b)
            {
                switchObject.OnTriggerEnter2D(GetComponent<Collider2D>());
            }
            else
            {
                switchObject.OnTriggerExit2D(GetComponent<Collider2D>());
            }
            
        }
    }
}
