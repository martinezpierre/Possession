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
        switchObject.transform.localEulerAngles = new Vector3(switchObject.transform.localEulerAngles.x, switchObject.transform.localEulerAngles.y, 340);
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
        Debug.Log(switchObject.transform.localEulerAngles.z);

        if((int)switchObject.transform.localEulerAngles.z >= 340)
        {
            while ((int)switchObject.transform.localEulerAngles.z >= 250)
            {
                float z = (int)switchObject.transform.localEulerAngles.z - 10;
                
                switchObject.transform.localEulerAngles = new Vector3(switchObject.transform.localEulerAngles.x, switchObject.transform.localEulerAngles.y, z);
                yield return new WaitForSeconds(0.01f);
            }
        }
        else
        {
            while ((int)switchObject.transform.localEulerAngles.z <= 340)
            {
                float z = (int)switchObject.transform.localEulerAngles.z + 10;
                
                switchObject.transform.localEulerAngles = new Vector3(switchObject.transform.localEulerAngles.x, switchObject.transform.localEulerAngles.y, z);
                yield return new WaitForSeconds(0.01f);
            }
        }
        
        yield return null;
    }
}
