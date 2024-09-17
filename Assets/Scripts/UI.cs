using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{

    public GameObject arrowAlertPrefab;

    private const int MAX_ALERTS = 100;
    private int current_arrow_integer = 0;
    private GameObject[] arrowArr;

    // Timers
    private float[] timers;
    public float alertPeriod = 0.25f;
    private int activeAlerts = 0;

    // Start is called before the first frame update
    void Start()
    {
        arrowArr = new GameObject[MAX_ALERTS];
        timers = new float[MAX_ALERTS];
        for(int i = 0; i < MAX_ALERTS; i++){
            // Instantiate and prepare arrows
            arrowArr[i] = Instantiate(arrowAlertPrefab);
            arrowArr[i].transform.parent = transform;
            arrowArr[i].transform.position = transform.position - new Vector3(0,0,-110); // move temp arrow out of the screen
            timers[i] = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate(){

        float currT = Time.time;
        int startIndex = (100 + current_arrow_integer - activeAlerts) % MAX_ALERTS; // Startindex -> current_integer - active Alerts ajustado al ciclo de 0,1,2...,97,98,99,0,1,2,3,...,97,98,99,0,1,2,...
        for(int i = startIndex; i!=current_arrow_integer; i=(i+1)%MAX_ALERTS){
            if(timers[i] != 0 && currT > timers[i]){
                timers[i] = 0; // unset timer
                arrowArr[i].transform.position = transform.position - new Vector3(0,0,-110); // reset arrow pos
                arrowArr[i].transform.rotation = Quaternion.Euler(0,0,0); // reset rotation // Maybe delete? Not really necesarry but for debug looks better
                activeAlerts--;
            }
        }
    }

    public void alert(float angle){

        GameObject arrow = arrowArr[current_arrow_integer];

        // Rotate arrow so it looks towards player
        arrow.transform.rotation = Quaternion.Euler(0,0,angle+90); 
        // Move arrow to where the meteorite will be comming from
        arrow.transform.position = new Vector2(transform.position.x + Mathf.Cos(angle*Mathf.Deg2Rad)*9, transform.position.y + Mathf.Sin(angle*Mathf.Deg2Rad)*(float)4.5);

        // Update timer in timer table
        timers[current_arrow_integer] = Time.time + alertPeriod;

        // Advance integers and alert counter
        current_arrow_integer = (current_arrow_integer+1) % MAX_ALERTS;
        activeAlerts++;
    }
}
