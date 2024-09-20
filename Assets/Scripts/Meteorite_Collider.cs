using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class Meteorite_Collider : MonoBehaviour
{

    public EnemySpawner spawner;

    public int hp;



    private Meteorite_Movement mm;
    private UI ui;

    // Start is called before the first frame update
    void Start()
    {
        hp = 10;
        mm = GetComponent<Meteorite_Movement>();
        ui = GameObject.Find("UI").GetComponent<UI>();
        spawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.name == "Player"){
            ui.removeShield();
            // Reset meteorite
            mm.speed = 0;
            transform.position = transform.parent.position;
            ui.updateScore(); // score++
        }
        else if(other.gameObject.layer == LayerMask.NameToLayer("Bullet") && other.GetComponent<Bullet_Movement>().speed > 0){

            if(transform.tag == "Meteorite"){ // if this is a big meteorite --> spawn two small ones
                spawner.SpawnSmallEnemy(mm.angle , mm.speed * (float) 0.3, transform.position);
            }

            // Reset meteorite
            mm.speed = 0;
            transform.position = transform.parent.position;
            ui.updateScore(); // score++

            // Reset bullet
            other.gameObject.GetComponent<Bullet_Movement>().Reset();
            
        }
    }
}
