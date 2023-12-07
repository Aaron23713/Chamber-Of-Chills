using System.Collections;
using System.Collections.Generic;
using AlpaSunFade;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] TransitionPanel t;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartScene(){
        SceneManager.LoadScene("Chambers");


    }
    public void QuitScene(){
        Application.Quit();

    }
    public void ReturnScene(){
        SceneManager.LoadScene("Main Menu");
    }

    public void FFade(){
       
        t.StartTransition(true, 0, 3);
    }
}
