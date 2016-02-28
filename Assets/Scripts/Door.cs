using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

    public bool opened = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Toogle()
    {
        opened = !opened;
        gameObject.SetActive(!opened);
    }
}
