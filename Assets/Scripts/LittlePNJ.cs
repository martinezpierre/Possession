using UnityEngine;
using System.Collections;

public class LittlePNJ : Controlable
{

    bool canMoveUp = false;

    bool canBeTaken = false;
    SimplePNJ taker = null;

    public GameObject EObject;

    public AnimationCurve walkingAnimCurve;

    float Timer;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();

        pC = FindObjectOfType<PlayerController>();

        Debug.Log(pC);
        if (EObject)
        {
            EObject.SetActive(false);
        }
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        MoveAnimation();

        if (canBeTaken && Input.GetKeyUp(KeyCode.E))
        {
            taker.Take(gameObject);
        }

        if (Vector2.Distance(pC.transform.position,transform.position) < 7f && pC.transform.parent && pC.transform.parent.tag == "PNJSimple" && usable)
        {
            canBeTaken = true;
            taker = pC.transform.parent.GetComponent<SimplePNJ>();


            if (EObject)
            {
                EObject.SetActive(true);
            }
        }
        else
        {
            canBeTaken = false;
            taker = null;
            if (EObject)
            {
                EObject.SetActive(false);
            }
        }
    }

    public void SetCanMoveUp(bool b)
    {
        if (pC.transform.parent.gameObject != gameObject) return;
        canMoveUp = b;
        canFall = canMoveUp ? false : true;

        Debug.Log("canFall " + canFall);
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

    void MoveAnimation()
    {
        Timer += Time.deltaTime;

        if (isMooving)
        {
            float newX = scaleX - 0.2f * walkingAnimCurve.Evaluate(Timer);
            
            Body.transform.localScale = new Vector3(newX, Body.transform.localScale.y, Body.transform.localScale.z);

            if (Timer > 1.0f) { Timer = 0; }
        }
    }
}
