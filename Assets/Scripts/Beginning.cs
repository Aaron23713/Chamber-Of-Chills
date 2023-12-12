using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beginning : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject clicking;
    public KeepTime time;
    // Start is called before the first frame update
    void Start()
    {
        // time.StartNewGame();
        audioSource.Play();
        StartCoroutine(TheWait());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator TheWait()
    {
        yield return new WaitForSeconds(40f);
        clicking.SetActive(true);
    }
}
