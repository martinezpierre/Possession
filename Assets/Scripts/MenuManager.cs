using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadLevel(string s)
    {
        SceneManager.LoadScene(s);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
