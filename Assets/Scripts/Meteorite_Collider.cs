using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorite_Collider : MonoBehaviour
{

    public GameObject spawner;

    public int hp;

    // Start is called before the first frame update
    void Start()
    {
        hp = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.name == "Player"){
            Debug.Log("HIT");
        }
        else if(other.gameObject.layer == LayerMask.NameToLayer("Bullet")){
            Debug.Log("METEORITE DESTROYED");
        }
    }
}
