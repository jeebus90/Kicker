using UnityEngine;
using System.Collections;

public class GameManagerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PlayerDeath(string message)
    {
        Debug.Log("Killed by " + ".\nYou died in a terrible horrible death maddafakka!!!");
    }
}
