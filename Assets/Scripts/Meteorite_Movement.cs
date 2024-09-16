using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Meteorite_Movement : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 0f;

    private GameObject player;

    private Vector2 dirToPlayer;
    private float angle;
    void Start()
    {
        player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate(){
        // Advance
        if(speed > 0){ // So it doesnt calc movement when in meteorite box / unused meteorite spawn
            transform.position = transform.position + transform.right * speed * Time.fixedDeltaTime;
        }
    }

    public void facePlayer(){
        // Calc direction to player
        dirToPlayer = (player.transform.position - transform.position).normalized;
        // Calc angle to player
        angle = Mathf.Atan2(dirToPlayer.y, dirToPlayer.x) * Mathf.Rad2Deg;
        Debug.Log(angle);
        // Rotate meteorite towards player
        transform.rotation = Quaternion.Euler(new Vector3(0,0,angle));
    }

    public void setSpeed(float speed){
        this.speed = speed;
    }
}
