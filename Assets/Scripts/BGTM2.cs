using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Background_Tile_Manager2 : MonoBehaviour
{

    public GameObject tile;

    private float len;

    private GameObject[,] tileMap = new GameObject[6,8]; // 4 rows and 6 columns

    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.Find("Player");
        // At start generate the tiles -> 24 tiles -> 8 in camera, 4 on the sides, 8 on top + bottom and 4 on the corners
        len = tile.GetComponent<Renderer>().bounds.size.x;



        for(int i = 0; i < 6; i++){
            for(int j = 0; j < 8; j++){
                GameObject newTile = Instantiate(tile);
                
                newTile.transform.position = new UnityEngine.Vector2((float) (len*j - 3.5*len),(float) (len*i - 2.5*len));
                newTile.transform.parent = this.transform;
                newTile.name = i + " - " + j;

                tileMap[i,j] = newTile;

            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
