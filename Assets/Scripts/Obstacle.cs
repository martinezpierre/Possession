using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

    bool usable = false;

    public GameObject EObject;

    // Use this for initialization
    void Start () {
        EObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (usable && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PNJBig")
        {
            usable = true;
            EObject.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        usable = false;
        EObject.SetActive(false);
    }
}
