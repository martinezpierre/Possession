using UnityEngine;
using System.Collections;

public class PNJ : Controlable {
    
    public float jumpHeight = 10f;
    
    // Use this for initialization
    protected override void Start () {
        base.Start();
        
    }

    // Update is called once per frame
    protected override void Update () {
        base.Update();
    }

    public override void Move()
    {
        base.Move();

        if (Input.GetKeyDown(KeyCode.Space) && !jumping && !isFalling)
        {
            StartCoroutine(Jump());
        }
    }

    bool SomethingAbove()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.up, distToGround + 0.1f);
        RaycastHit2D hit2 = Physics2D.Raycast(new Vector3(transform.position.x + GetComponent<Collider2D>().bounds.extents.x, transform.position.y, transform.position.z), Vector3.up, distToGround + 0.1f);
        RaycastHit2D hit3 = Physics2D.Raycast(new Vector3(transform.position.x - GetComponent<Collider2D>().bounds.extents.x, transform.position.y, transform.position.z), Vector3.up, distToGround + 0.1f);
        
        return (hit && hit.transform.tag == "Obstacle") || (hit2 && hit2.transform.tag == "Obstacle") || (hit3 && hit3.transform.tag == "Obstacle");
    }

    IEnumerator Jump()
    {
        jumping = true;

        bool canJump = true;

        Vector3 beginingPosition = transform.position;

        while(transform.position.y - beginingPosition.y < jumpHeight && canJump)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);

            canJump = !SomethingAbove();
            
            yield return new WaitForEndOfFrame();
        }

        float timer = Time.time;

        while(Time.time - timer < 1f && Input.GetKey(KeyCode.Space))
        {
            yield return new WaitForEndOfFrame();
        }
        
        jumping = false;
    }
}
