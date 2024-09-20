using UnityEngine;

public class Gun : MonoBehaviour
{

    public GameObject bulletPrefab;
    private GameObject activeBulletFolder;

    public float cooldown = 0.025f;
    private float lastFireTime = 0f;


    private const int MAX_BULLETS = 100;
    private const float BULLET_SPEED = 25f;
    private int current_bullet_index = 0;

    private GameObject[] bullets;
    // Start is called before the first frame update
    void Start()
    {
        activeBulletFolder = GameObject.Find("ActiveBulletFolder");
        bullets = new GameObject[MAX_BULLETS];
        for(int i = 0; i<MAX_BULLETS; i++){
            bullets[i] = Instantiate(bulletPrefab);
            //bullets[i].transform.position = transform.position; // Spawn at the position of the gun, under the player, so it cant be seen until speed is given to it
            bullets[i].transform.parent = transform; // Set gun as parent of bullet for order in scene
            bullets[i].name = "Bullet - " + i;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetMouseButtonDown(0) || Input.GetMouseButton(0)) && Time.time > lastFireTime + cooldown){
            lastFireTime = Time.time;
            Fire();
        }
    }

    void FixedUpdate(){
    }

    void Fire(){
        GameObject bullet = bullets[current_bullet_index];
        bullet.transform.rotation = transform.parent.rotation; // Set rotation same as player rotation
        bullet.transform.position = transform.position; // Set position to gun in case its an already fired bullet
        bullet.GetComponent<Bullet_Movement>().speed = BULLET_SPEED; // Set bullet speed
        bullet.transform.parent = activeBulletFolder.transform; // Detach from player so player movement doesnt affect the bullets
        current_bullet_index = (current_bullet_index+1)%MAX_BULLETS;
    }
}
