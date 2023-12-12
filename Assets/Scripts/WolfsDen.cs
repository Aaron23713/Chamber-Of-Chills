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
    public GameObject click;
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
        click.SetActive(false);
        aud.Play();
        playerMotion.SetActive(false);
        yield return new WaitForSeconds(22.335f);

        
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
        click.SetActive(true);
    }
}
