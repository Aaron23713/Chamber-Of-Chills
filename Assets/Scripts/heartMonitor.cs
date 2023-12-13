using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
public class heartMonitor : MonoBehaviour
{
    private Image[] images;
    private AudioSource[] audios;
    public Color myColor = Color.red;

  
    public bool hasPlayed = false;
    public int currentHeartLevel = 0;
    public XRBaseController leftController;
    public XRBaseController rightController;
    public bool ANroom1 = false;


    
    
    // Start is called before the first frame update
    void Start(){
        images = GetComponentsInChildren<Image>();
        audios = GetComponentsInChildren<AudioSource>();
    }

    void Update(){
        if(currentHeartLevel == 10){ 
            StartCoroutine(TheWait());
            SceneManager.LoadScene("Main Menu");
        }
    }
    
    
    void OnTriggerEnter(Collider other)
    {
        // Check if the collider is triggered and the sound hasn't been played yet
        if (other.CompareTag("heartRace"))
        {
            audios[0].Play();
            leftController.SendHapticImpulse(1.0f,1.5f);
            rightController.SendHapticImpulse(1.0f,1.5f);

            if(currentHeartLevel == 0){
            audios[1].Play();
            }else{
                if(currentHeartLevel > 1 && audios[currentHeartLevel - 1].isPlaying){
                     audios[currentHeartLevel - 1].Stop();
                }
                audios[currentHeartLevel].Play();
            }
            images[currentHeartLevel].color = myColor;
            hasPlayed = true;
            currentHeartLevel++;
            other.GameObject().SetActive(false);
        }
    }
    public void manualHeartIncrease(){
        audios[0].Play();
        leftController.SendHapticImpulse(1.0f,1.5f);
        rightController.SendHapticImpulse(1.0f,1.5f);
        if(currentHeartLevel == 0){
            audios[1].Play();
            }else{
                if(currentHeartLevel > 1 && audios[currentHeartLevel - 1].isPlaying){
                     audios[currentHeartLevel - 1].Stop();
                }
                audios[currentHeartLevel].Play();
            }
        images[currentHeartLevel].color = myColor;
        currentHeartLevel++;
    }
    public void manualHeartIncreaseANroom1(){
        if(ANroom1 == false){
        audios[0].Play();
        leftController.SendHapticImpulse(1.0f,1.5f);
        rightController.SendHapticImpulse(1.0f,1.5f);
        if(currentHeartLevel == 0){
            audios[1].Play();
            }else{
                if(currentHeartLevel > 1 && audios[currentHeartLevel - 1].isPlaying){
                     audios[currentHeartLevel - 1].Stop();
                }
                audios[currentHeartLevel].Play();
            }
        images[currentHeartLevel].color = myColor;
        currentHeartLevel++;
        ANroom1 = true;
        }
    }

    IEnumerator TheWait()
    {
    
        yield return new WaitForSeconds(11f);
    }
}
