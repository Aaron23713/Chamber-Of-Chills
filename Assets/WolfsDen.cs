using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WolfsDen : MonoBehaviour
{
    public GameObject player;
    public GameObject playerMotion;
    public GameObject lighter;
    public AudioSource aud;
    public AudioSource lightShutOff;
    public AudioSource evilVoice;
    public AudioSource wolfSound;
    public bool oneTime = false;
    public GameObject wolf;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public void BeginningOfTheEnd()
    {
        if (!oneTime)
        {
            StartCoroutine(TheWait());
        }
        oneTime = true;
    }

    IEnumerator TheWait()
    {
        aud.Play();

        yield return new WaitForSeconds(23f);

        playerMotion.SetActive(false);
        lightShutOff.Play();
        player.SetActive(false);
        lighter.SetActive(false);
        yield return new WaitForSeconds(4f);
        wolfSound.Play();
        evilVoice.Play();
        yield return new WaitForSeconds(25f);
        player.SetActive(true);
        playerMotion.SetActive(true);
        wolf.SetActive(true);
    }
}
