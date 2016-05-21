using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    Controlable currentBody;

    LineRenderer lineRenderer;

    public Color possessionColor;
    
    // Use this for initialization
    void Start()
    {
        currentBody = transform.parent.GetComponent<Controlable>();
        
    }
    
    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        currentBody.Move();
    }
    
    public void ChangeBody(Transform t)
    {

        StartCoroutine(ChangeAnim(t));
        
    }

    IEnumerator ChangeAnim(Transform target)
    {
        yield return null;
        
        transform.parent = null;

        float timer = Time.time;

        Transform t;

        if(target.GetChild(0).name == "target")
        {
            t = target.GetChild(0);
        }
        else
        {
            t = target;
        }

        while (t && transform && Vector2.Distance(t.position, transform.position) > 0.01f && Time.time - timer < .2f)
        {
            float step = 100f * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, t.position, step);
            
            yield return new WaitForSeconds(0.01f);
        }
        
        transform.parent = target;

        currentBody.TakeControl(false);

        if (target)
        {
            currentBody = target.GetComponent<Controlable>();
            currentBody.Body.color = possessionColor;
        }

        transform.position = t.transform.position;
    }
}