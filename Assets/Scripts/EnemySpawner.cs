using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject[] enemyPrefabList;

    private GameObject player;
    private UI ui;

    private GameObject[] normalMeteorite;


    // Enemy spawn const and vars
    private const int MAX_ENEMY_AMM = 100;
    private const int SPAWN_DISTANCE = 15;
    private int current_enemy_index = 0;

    // Timer const and vars
    private float nextSpawnTime = 0f;
    public float spawnPeriod = 2f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        ui = GameObject.Find("UI").GetComponent<UI>();

        normalMeteorite = new GameObject[100];
        for (int i = 0; i < MAX_ENEMY_AMM; i++){
            normalMeteorite[i] = Instantiate(enemyPrefabList[0]);
            normalMeteorite[i].transform.position = transform.position; // spawn it in a weird location so it cant be seen
            normalMeteorite[i].transform.parent = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate(){
        if(Time.time > nextSpawnTime){
            nextSpawnTime += spawnPeriod;
            SpawnEnemy();
        }
    }

// If player closes in on spawnbox ->
    void OnTriggerEnter2D(Collider2D other){
        if(other.name == "Player"){
            // TP Spawnbox to other side of the world
            transform.position = new Vector3(-transform.position.x,-transform.position.y, transform.position.z);
            // Move all meteorites
            foreach(GameObject meteorite in normalMeteorite){
                meteorite.transform.position = transform.position;
            }
        }
    }

    void SpawnEnemy(){
        // Get next spawnable element
        GameObject curr_meteorite = normalMeteorite[current_enemy_index];

        // Set a random angle at which the meteorite will come from
        float randAngle = Random.Range(1,360);

        // Rotate the meteorite that angle
        curr_meteorite.transform.rotation = Quaternion.Euler(0,0,randAngle + 180);
        // Spawn arrow alert on screen
        ui.alert(randAngle);

        // Put the meteorite at that angle at a distance of 30
        randAngle = randAngle * Mathf.Deg2Rad;
        curr_meteorite.transform.position = new Vector2(player.transform.position.x + SPAWN_DISTANCE * Mathf.Cos(randAngle), player.transform.position.y + SPAWN_DISTANCE * Mathf.Sin(randAngle));

        

        // Set a random speed
        int randSpeed = Random.Range(15,30);
        curr_meteorite.GetComponent<Meteorite_Movement>().setSpeed(randSpeed);

        // Prepare index for next spawnable element
        current_enemy_index = (current_enemy_index+1) % MAX_ENEMY_AMM;        
    }
}
