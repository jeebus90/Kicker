using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed;
    private float lastTime;
    private Vector3 movement;
    // Update is called once per frame
    void Start()
    {
        lastTime = Time.time;
    }
    
    void Update()
    {
        if (Time.time > (lastTime + 1))
        {
            if(Input.GetButtonDown()) 
                horizontalMovement = Input.GetAxis("Horizontal");
            float verticalMovement = Input.GetAxis("Vertical");

            movement = new Vector3(horizontalMovement, 0.0f, verticalMovement);
            if (movement.x > 0.0000000001) movement.x = 1;
            if (movement.z > 0.0000000001) movement.z = 1;
            rigidbody.AddForce(movement * speed);
            lastTime = Time.time;
        }
    }

    void OnTriggerEnter(Collider other)
    {
    }
}
