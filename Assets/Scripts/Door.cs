using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

    public bool opened = false;

    Vector3 openPos;
    Vector3 closedPos;

    // Use this for initialization
    void Start () {
        closedPos = transform.position;
        openPos = transform.position + transform.GetChild(0).transform.up * 12;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Toogle()
    {
        opened = !opened;
        //gameObject.SetActive(!opened);
        StartCoroutine(AnimationOnOff());
    }

    IEnumerator AnimationOnOff()
    {
        if (transform.position == closedPos)
        {
            while (transform.position != openPos)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z) + transform.GetChild(0).transform.up;
                yield return new WaitForSeconds(0.01f);
            }
        }
        else
        {
            while (transform.position != closedPos)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z) - transform.GetChild(0).transform.up;
                yield return new WaitForSeconds(0.01f);
            }
        }

        yield return null;
    }
}
