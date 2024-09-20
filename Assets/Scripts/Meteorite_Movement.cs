using UnityEngine;

public class Meteorite_Movement : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 0f;

    private GameObject player;

    private Vector2 dirToPlayer;
    public float angle;
    private const float DESPAWN_DISTANCE = 150f;
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
            if((transform.position - player.transform.position).magnitude > DESPAWN_DISTANCE){ 
                speed = 0; // stop movement
                transform.position = transform.parent.position; // Put naughty meteorite in meteorite chamber
            }
        }
    }
    public void setSpeed(float speed){
        this.speed = speed;
    }
}
