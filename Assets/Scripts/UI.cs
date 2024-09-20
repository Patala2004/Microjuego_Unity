using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{

    public GameObject arrowAlertPrefab;
    private ScreenShake cameraShake;
    private GameObject deadScreen;

    private const int MAX_ALERTS = 100;
    private int current_arrow_integer = 0;
    private GameObject[] arrowArr;

    private Text score_canvas;
    private int score = 0;
    private int shields = 5;

    // Timers
    private float[] timers;
    public float alertPeriod = 0.25f;
    private int activeAlerts = 0;

    // Start is called before the first frame update
    void Start()
    {
        deadScreen = GameObject.Find("DeadScreen");
        deadScreen.SetActive(false);
        cameraShake = transform.parent.GetComponent<ScreenShake>();
        score_canvas = GetComponentInChildren<Text>();
        score_canvas.text = "Score: 0";
        arrowArr = new GameObject[MAX_ALERTS];
        timers = new float[MAX_ALERTS];
        for(int i = 0; i < MAX_ALERTS; i++){
            // Instantiate and prepare arrows
            arrowArr[i] = Instantiate(arrowAlertPrefab);
            arrowArr[i].SetActive(false);
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
                arrowArr[i].SetActive(false); // Hide arrow
                activeAlerts--;
            }
        }
    }

    public void alert(float angle){

        GameObject arrow = arrowArr[current_arrow_integer];
        arrow.SetActive(true); // Show arrow

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

    public void updateScore(){
        score_canvas.text = "Score: " + ++score;
    }

    public void removeShield(){
        if(shields == 0){
            // If you dont have shields when hit you die
            deadScreen.SetActive(true); // Show deadscreen
            Time.timeScale = 0; // Pause deltaTime (movement and animations)

        }
        else{
            GameObject shieldSprite = GameObject.Find("Energy" + shields);
            shieldSprite.SetActive(false); // Hide sprite
            shields--;

            // add camera tumbling effect when hit
            cameraShake.TriggerShake(); 
        }   

        
    }
}
