using UnityEngine;
using System.Collections;

public class MainMenu_Controller : MonoBehaviour {
    private int count = 0;
    private int columns = 5, buttonSize, spacing, numberOfLevels = 11;

	void Start () {
        Screen.orientation = ScreenOrientation.Portrait;
        buttonSize = Screen.width / (columns + 1);
        spacing = 10;
	}
	
    void OnGUI() {

        int currentRow = 0;
        int currentColumn = 0;
        for (int i = 0; i < numberOfLevels; i++)
        {
            if (GUI.Button(new Rect(spacing + (buttonSize + spacing) * currentColumn, spacing + (buttonSize + spacing) * currentRow, buttonSize, buttonSize), "Level " + (1 + i)))
            {
                Application.LoadLevel("scene"+(i+1));
            }

            currentColumn++;
            if(currentColumn>=columns){
                currentColumn = 0;
                currentRow ++;
          }


        }

            
    
    
    }
}
