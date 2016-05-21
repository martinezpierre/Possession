using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour {

    public Image blackFade;

	// Use this for initialization
	void Start () {
        StartCoroutine(SplashAnim());
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator SplashAnim()
    {
        while (blackFade.color.a > 0.01f)
        {
            blackFade.color = new Color(blackFade.color.r, blackFade.color.g, blackFade.color.b, blackFade.color.a - 0.05f);
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(2f);

        while (blackFade.color.a < 0.99f)
        {
            blackFade.color = new Color(blackFade.color.r, blackFade.color.g, blackFade.color.b, blackFade.color.a + 0.05f);
            yield return new WaitForSeconds(0.05f);
        }

        SceneManager.LoadScene("Menu");
    }
}
