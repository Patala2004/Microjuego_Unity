using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{

    private Transform player;
    private Player_Movement playerMov;

    private Camera cam;
    public float smoothSpeed = 0.125f;  // Speed at which the camera follows
    public Vector3 offset;          // Offset distance between the player and camera

    private float maxSpeed;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        GameObject playerObj = GameObject.Find("Player");
        player = playerObj.transform;
        playerMov = playerObj.GetComponent<Player_Movement>();
        maxSpeed = playerMov.maxSpeed;

        offset = new Vector3(0,0,transform.position.z);
    }
    void LateUpdate()
    {
        // Calculate desired position with offset
        transform.position =  player.transform.position + offset + player.transform.right * playerMov.speed / 7; // Camera a bit behind based on speed for velocity effect

        cam.orthographicSize = 5 + 2*(playerMov.speed / maxSpeed); // Speed between 5 - 7 based on curr speed relative to max speed
        
    }
}

