using UnityEngine;

public class Background_Tile_Manager : MonoBehaviour
{

    private GameObject player;

    private Collider2D col;
    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.Find("Player");

        col = GetComponent<CompositeCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other){
        // When entering the edges of the map 

        Vector2 difference = (Vector2) (player.transform.position - transform.position);

        // Check if entering from left, right, top, bottom or on the edges
        if(difference.x <= -23){
            // Move tilemap to the left
            transform.position = (Vector2) transform.position + new Vector2(-30,0);
        }
        else if(difference.x >= 23){
            transform.position = (Vector2) transform.position + new Vector2(30,0);
        }
        if(difference.y >= 13){
            transform.position = (Vector2) transform.position + new Vector2(0,20);
        }
        else if(difference.y <= -13){
            transform.position = (Vector2) transform.position + new Vector2(0,-20);
        }
    }

    
}
