using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Switch : MonoBehaviour {

    bool usable = false;

    public GameObject EObject;

    public List<Door> doors;
    
    public GameObject switchObject;

	// Use this for initialization
	void Start () {
        EObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
	    if(usable && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(AnimationOnOff());
            foreach (Door d in doors)
            {
                d.Toogle();
            }
        }
	}
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "PNJSpecial")
        {
            usable = true;
            EObject.SetActive(true);
            other.GetComponent<Controlable>().switchObject = this;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        usable = false;
        EObject.SetActive(false);
    }

    IEnumerator AnimationOnOff()
    {
        if((int)switchObject.transform.localEulerAngles.z == 0)
        {
            while ((int)switchObject.transform.localEulerAngles.z != 270)
            {
                switchObject.transform.localEulerAngles = new Vector3(switchObject.transform.localEulerAngles.x, switchObject.transform.localEulerAngles.y, switchObject.transform.localEulerAngles.z - 10);
                yield return new WaitForSeconds(0.01f);
            }
        }
        else
        {
            while ((int)switchObject.transform.localEulerAngles.z != 0)
            {
                switchObject.transform.localEulerAngles = new Vector3(switchObject.transform.localEulerAngles.x, switchObject.transform.localEulerAngles.y, switchObject.transform.localEulerAngles.z + 10);
                yield return new WaitForSeconds(0.01f);
            }
        }
        
        yield return null;
    }
}
