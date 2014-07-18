using UnityEngine;
using System.Collections;

public class Enemy_script : MonoBehaviour {

    public GameObject gameManager;
    public GameObject player;
    public float force;
    private float distToGround;

	// Use this for initialization
	void Start () {
        distToGround = collider.bounds.extents.y;
	}

    void Update()
    {
        if (IsGrounded())
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            rigidbody.AddForce(direction * force);
        }
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
    bool IsGrounded()
    {
        //TODO works bad if uneven ground!
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.4f);

    }
}
