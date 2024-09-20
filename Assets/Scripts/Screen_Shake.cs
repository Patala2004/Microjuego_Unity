using System.Collections;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public float shakeDuration = 1.2f;
    public float shakeAmount = 25.2f;
    public float decreaseFactor = 1.0f;

    public bool isShaking = false;

    private GameObject player;

    Vector3 originalPos;
    float currentShakeDuration;

    public Vector3 offset;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    public void TriggerShake()
    {
        offset = new Vector3(0,0,transform.position.z);
        originalPos = transform.position;   
        currentShakeDuration = shakeDuration;
        isShaking = true;
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        while (currentShakeDuration > 0)
        {
            originalPos = player.transform.position + offset + player.transform.right * player.GetComponent<Player_Movement>().speed / 7;
            transform.position = originalPos + Random.insideUnitSphere * shakeAmount;
            currentShakeDuration -= Time.deltaTime * decreaseFactor;

            yield return null;
        }

        transform.position = originalPos;
        isShaking = false;
    }
}
