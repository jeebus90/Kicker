using UnityEngine;
using System.Collections;

public class Danger_Script : MonoBehaviour {

    GameObject gameManager;



    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            GameManagerScript script = gameManager.GetComponent<GameManagerScript>();
            script.PlayerDeath("danger");
        }
    }
}
