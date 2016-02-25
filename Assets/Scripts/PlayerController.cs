using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    Controlable currentBody;


    // Use this for initialization
    void Start()
    {
        currentBody = transform.parent.GetComponent<Controlable>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        currentBody.Move();
    }

    public void ChangeBody(Transform t)
    {

        StartCoroutine(ChangeAnim(t));
        
    }

    IEnumerator ChangeAnim(Transform t)
    {
        yield return null;

        while(Vector2.Distance(t.position, transform.position) > 0.01f)
        {
            float step = 100f * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, t.position, step);
            yield return new WaitForSeconds(0.01f);
        }

        currentBody.usable = true;

        currentBody = t.GetComponent<Controlable>();
        transform.parent = t;

        transform.localPosition = Vector3.zero;
    }
}