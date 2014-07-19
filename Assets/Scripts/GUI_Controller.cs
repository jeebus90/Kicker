using UnityEngine;
using System.Collections;

public class GUI_Controller : MonoBehaviour {

    public GameObject player;
    public Texture boltTexture;

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {



	
	}
    void OnGUI()
    {
        int steps = player.GetComponent<Player_Controller_Android>().steps;
        for (int i = 0; i < steps; i++) { 
            GUI.DrawTexture(new Rect(Screen.width-30*i, Screen.height - 80, 20, 40), boltTexture, ScaleMode.StretchToFill, true, 10.0F);
        } 
    }

}
