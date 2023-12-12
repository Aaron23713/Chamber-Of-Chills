using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickBehavior : MonoBehaviour
{
    public AudioSource audioSource;
    public float timer;
    private bool playing;
    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(6f,20f);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0f && playing == false){
            audioSource.Play();
            timer = Random.Range(8f,16f);
        }
    }
}
