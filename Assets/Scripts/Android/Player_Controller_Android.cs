using UnityEngine;
using System.Collections;

public class Player_Controller_Android : MonoBehaviour
{

    public float speed;
    private Vector3 movement;
    private float distToGround;
    private Vector2 screenMid;
    public int steps;
    public Texture boltTexture;


    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        distToGround = collider.bounds.extents.y;
        screenMid = new Vector2(Screen.width / 2.0f, Screen.height / 2.0f);
    }

    void Update()
    {

        try
        {
            Vector2 touchPosition = Input.GetTouch(0).position;
            if (Input.GetTouch(0).phase == TouchPhase.Began && steps > 0)
            {
                Ray ray = Camera.main.ScreenPointToRay(touchPosition);
                float distance = 150;
                //Vector3 point = ray.origin + (ray.direction * distance);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, distance))
                {
                    if (hit.transform.CompareTag("TouchArea")) ;
                    {
                        steps -= 1;
                        Vector3 directionVector = (hit.point - transform.position).normalized;
                        movement = new Vector3(directionVector.x * speed, 0.0f, directionVector.z * speed);
                        rigidbody.AddForce(movement);
                    }
                }
            }
        }
        catch (UnityException e)
        {
        }
    }
  
    void LateUpdate(){
    if(transform.position.y < -2)
        {
            restartLevel();
        }
    }
    public void restartLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Goal")
        {
            Debug.Log("asdf");
            other.GetComponent<Goal_script>().enterNextLevel();
            collider.enabled = false;
            rigidbody.velocity = Vector3.Lerp(rigidbody.velocity,new Vector3(0, 0, 0),0.4f);
            rigidbody.angularVelocity = new Vector3(0, 0, 0);
        }

    }

    void smoothResetSpeeds(Rigidbody rb)
    {
        Vector3 currentSpeeds = rb.velocity;
        currentSpeeds.z = Mathf.Lerp(currentSpeeds.z, 0.0f, 0.5f);
        rb.velocity = currentSpeeds;
    }

    bool IsGrounded()
    {
        //TODO works bad if uneven ground!
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }
    void OnGUI()
    {
        for (int i = 0; i < steps; i++)
        {
            GUI.DrawTexture(new Rect(Screen.width - 30 * i, Screen.height - 80, 20, 40), boltTexture, ScaleMode.StretchToFill, true, 10.0F);
        }
    }

}