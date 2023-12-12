using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KeepTime : MonoBehaviour
{
    private  static KeepTime times;
    public float elapsedTime;
    public bool gameEnded = false;
    // Start is called before the first frame update
    void Awake()
    {
         if (times == null)
        {
            times = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!gameEnded)
        {
            // Update the elapsed time
            elapsedTime += Time.deltaTime;
        }
    }
    public void EndGame()
    {
        // Add any game ending logic here
        gameEnded = true;
        Debug.Log("Game ended after " + elapsedTime + " seconds.");
    }
     public void StartNewGame()
    {
        // Reset the time variables when starting a new game
        elapsedTime = 0f;
        gameEnded = false;
    }
}
