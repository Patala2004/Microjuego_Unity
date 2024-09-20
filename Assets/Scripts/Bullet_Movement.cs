using UnityEngine;

public class Bullet_Movement : MonoBehaviour
{

    public float speed = 0f;
    public Rigidbody2D rb;
    private const float DESPAWN_DISTANCE = 50f;

    private GameObject player;
    private GameObject gun;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        gun = GameObject.Find("Gun");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate(){
        if(speed > 0){ // So it doesnt calculate movement when 'at the chamber'
            rb.MovePosition(rb.position + (Vector2) transform.right * speed * Time.fixedDeltaTime);
            if((transform.position - player.transform.position).magnitude > DESPAWN_DISTANCE){ 
                Reset();
            }
        }
    }

    public void Reset(){
        // Put bullet back in chamber
        speed = 0;
        transform.parent = gun.transform;
        transform.position = transform.parent.position; // Put at same pos as the 'Gun' object
    }
}
