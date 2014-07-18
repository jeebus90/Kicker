using UnityEngine;
using System.Collections;

public class Player_Controller : MonoBehaviour
{

    public float speed;
    private Vector3 movement;
    private float distToGround;
    // Update is called once per frame
    void Start()
    {
        distToGround = collider.bounds.extents.y;
    }

    void Update()
    {
        if (Input.anyKey)
        {


            if (IsGrounded())
            {
                Rigidbody rb = GetComponent<Rigidbody>();


                if (Input.GetButton("Right"))
                {

                    movement = new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
                    if (rb.velocity.x < 0.0f)
                    {
                        smoothResetSpeeds(rb);
                    }
                    rigidbody.AddForce(movement);
                }
                if (Input.GetButton("Left"))
                {

                    movement = new Vector3(-speed * Time.deltaTime, 0.0f, 0.0f);
                    if (rb.velocity.x > 0.0f)
                    {
                        smoothResetSpeeds(rb);
                    }
                    rigidbody.AddForce(movement);
                }
                if (Input.GetButton("Up"))
                {

                    movement = new Vector3(0.0f, 0.0f, speed * Time.deltaTime);
                    if (rb.velocity.z < 0.0f)
                    {
                        smoothResetSpeeds(rb);
                    }
                    rigidbody.AddForce(movement);
                }
                if (Input.GetButton("Down"))
                {

                    movement = new Vector3(0.0f, 0.0f, -speed * Time.deltaTime);
                    if (rb.velocity.z > 0.0f)
                    {
                        smoothResetSpeeds(rb);
                    }
                    rigidbody.AddForce(movement);
                }

            }
        }
    }

    void smoothResetSpeeds(Rigidbody rb)
    {
        Vector3 currentSpeeds = rb.velocity;
        currentSpeeds.z = Mathf.Lerp(currentSpeeds.z, 0.0f, 0.1f);
        rb.velocity = currentSpeeds;
    }

    bool IsGrounded()
    {
        //TODO works bad if uneven ground!
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }
}