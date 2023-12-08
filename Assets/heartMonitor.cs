using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class heartMonitor : MonoBehaviour
{
    private Image[] images;
    public Color myColor = Color.red;

    public AudioSource audios;
    public bool hasPlayed = false;
    public int currentHeartLevel = 0;
    
    // Start is called before the first frame update
    void Start(){
        images = GetComponentsInChildren<Image>();
    }

    void Update(){
        if(currentHeartLevel == 10){
            SceneManager.LoadScene("Main Menu");
        }
    }
    
    
    void OnTriggerEnter(Collider other)
    {
        // Check if the collider is triggered and the sound hasn't been played yet
        if (other.CompareTag("heartRace"))
        {
            audios.Play();
            images[currentHeartLevel].color = myColor;
            hasPlayed = true;
            currentHeartLevel++;
        }
    }

    void buttonOn(){
        
    }
}
