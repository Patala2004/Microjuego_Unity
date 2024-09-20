using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float maxSpeed = 5f; // multiple of 1.0 or 0.5 if possible
    public float acceleration = 0.1f; // make a division of 1 if possible

    private Rigidbody2D rb;

    private Vector2 movement;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = acceleration;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get input from the player (WASD / Arrow keys)
        movement.x = Input.GetAxisRaw("Horizontal");  // Left (-1) / Right (+1)
        movement.y = Input.GetAxisRaw("Vertical");    // Down (-1) / Up (+1)
    }

    void FixedUpdate()
    {
        // Rotate Body based on input
        transform.Rotate(0,0,-movement.x * 250f * Time.deltaTime);
        // Accelerate based on input
         // Speed can only be between 0 and maxSpeed
        speed += (float) acceleration * movement.y;
        if(speed > maxSpeed){
            speed = maxSpeed;
        }
        else if(speed < 0.2){
            speed = 0.2f;
        }

        
        // Advance
        rb.MovePosition(rb.position + (Vector2) transform.right * speed * Time.fixedDeltaTime);
    }
}
