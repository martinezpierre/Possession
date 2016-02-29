using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

    bool usable = false;

    public GameObject EObject;

    PlayerController pC;

    // Use this for initialization
    void Start () {
        EObject.SetActive(false);

        pC = FindObjectOfType<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
        if (usable && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(gameObject);
        }

        if (Vector2.Distance(pC.transform.position, transform.position) < 7f && pC.transform.parent && pC.transform.parent.tag == "PNJBig")
        {
            usable = true;
            EObject.SetActive(true);
        }
        else
        {
            usable = false;
            EObject.SetActive(false);
        }
    }
}
