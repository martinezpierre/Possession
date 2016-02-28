using UnityEngine;
using System.Collections;

public class DeathZone : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponentInChildren<PlayerController>())
        {
            Application.LoadLevel(Application.loadedLevel);
        }
        else
        {
            Destroy(other.gameObject,1f);
        }
    }
}
