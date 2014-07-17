using UnityEngine;
using System.Collections;

public class Enemy_script : MonoBehaviour {

    public GameObject gameManager;
    public GameObject player;
    public float force;

	// Use this for initialization
	void Start () {
	}

	void Update () {
        rigidbody.AddForce((player.transform.position - transform.position).normalized * force);
	}

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            GameManagerScript script = gameManager.GetComponent<GameManagerScript>();
            script.PlayerDeath("uglyfAce");
        }
        else if (other.gameObject.tag == "Danger") {
            Destroy(gameObject);
        }
    }
}
