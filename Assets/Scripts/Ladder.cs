using UnityEngine;
using System.Collections;

public class Ladder : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PNJLittle")
        {
            other.GetComponent<LittlePNJ>().SetCanMoveUp(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "PNJLittle")
        {
            other.GetComponent<LittlePNJ>().SetCanMoveUp(false);
        }
    }
}
