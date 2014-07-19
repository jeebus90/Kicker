using UnityEngine;
using System.Collections;

public class Camera_followScript : MonoBehaviour {
    public GameObject player;
    private Vector3 originalPosition;
    private Vector3 originalPlayerPosition;
   // private Vector3 originalCameraLookAt;
    void Start()
    {
        originalPosition = transform.position;
        originalPlayerPosition = player.transform.position;
        //originalCameraLookAt = this.transform.rotation;
    }
	void Update () {
        transform.position = originalPosition + (player.transform.position - originalPlayerPosition);
        //transform.LookAt(player.transform.position);
	}
}
