using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Meteorite_Collider : MonoBehaviour
{

    public GameObject spawner;

    public int hp;

    private Meteorite_Movement mm;
    private UI ui;

    // Start is called before the first frame update
    void Start()
    {
        hp = 10;
        mm = GetComponent<Meteorite_Movement>();
        ui = GameObject.Find("UI").GetComponent<UI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.name == "Player"){
            Debug.Log("HIT");
        }
        else if(other.gameObject.layer == LayerMask.NameToLayer("Bullet") && other.GetComponent<Bullet_Movement>().speed > 0){
            mm.speed = 0;
            transform.position = transform.parent.position;
            ui.updateScore(); // score++
        }
    }
}
