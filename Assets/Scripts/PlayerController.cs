using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    Controlable currentBody;

    LineRenderer lineRenderer;

    // Use this for initialization
    void Start()
    {
        currentBody = transform.parent.GetComponent<Controlable>();

        float theta_scale = 0.1f;             //Set lower to add more points
        int size = (int)((2.0 * Mathf.PI) / theta_scale); //Total number of points in circle.

        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
        lineRenderer.SetColors(Color.black, Color.blue);
        lineRenderer.SetWidth(0.2F, 0.2F);
        lineRenderer.SetVertexCount(size+1);

        int i = 0;
        for (float theta = 0; theta < 2 * Mathf.PI; theta += 0.1f)
        {
            float x = 12f * Mathf.Cos(theta);
            float y = 12f * Mathf.Sin(theta);

            Vector3 pos = new Vector3(x, y, 0);


            Debug.Log(i + " " + pos);

            lineRenderer.SetPosition(i, pos);
            i += 1;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);
        }

        currentBody.Move();

        float theta_scale = 0.1f;             //Set lower to add more points
        int size = (int)((2.0 * Mathf.PI) / theta_scale); //Total number of points in circle.
        
        lineRenderer.SetWidth(0.2F, 0.2F);
        lineRenderer.SetVertexCount(size + 1);

        int i = 0;
        for (float theta = 0; theta < 2 * Mathf.PI; theta += 0.1f)
        {
            float x = transform.position.x + 12f * Mathf.Cos(theta);
            float y = transform.position.y + 12f * Mathf.Sin(theta);

            Vector3 pos = new Vector3(x, y, 0);
            
            lineRenderer.SetPosition(i, pos);
            i += 1;
        }
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


        transform.parent = t;

        currentBody.TakeControl(false);

        currentBody = t.GetComponent<Controlable>();

        transform.localPosition = Vector3.zero;
    }
}