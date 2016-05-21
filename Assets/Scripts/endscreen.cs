using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class endscreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(endscree());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator endscree()
    {
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene("Menu");
    }
}
