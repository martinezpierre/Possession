using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

    // Use this for initialization
    PlayerController pC;

    // Use this for initialization
    void Start()
    {
        pC = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update () {
        if (Vector2.Distance(pC.transform.position, transform.position) < 2f)
        {
            Debug.Log("endLevel");
        }
    }
}
