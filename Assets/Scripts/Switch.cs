using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Switch : MonoBehaviour {

    bool usable = false;

    public GameObject EObject;

    public List<Door> doors;

	// Use this for initialization
	void Start () {
        EObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	    if(usable && Input.GetKeyDown(KeyCode.E))
        {
            foreach(Door d in doors)
            {
                d.Toogle();
            }
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "PNJSpecial")
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
