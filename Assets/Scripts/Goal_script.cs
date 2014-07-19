using UnityEngine;
using System.Collections;

public class Goal_script : MonoBehaviour {
    public string nextLevel;

    public void enterNextLevel() {
        Application.LoadLevel(nextLevel);
    }
}
