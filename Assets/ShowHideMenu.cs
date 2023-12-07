using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideMenu : MonoBehaviour
{
    public GameObject menu;
    public Transform controller;
    public Transform target;
    public float showMenuThreshold = 30;
    public float hideMenuThreshold = 40;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float angle = Vector3.Angle(controller.right, target.right); // Comparing local X axes

        if (angle < showMenuThreshold){
            menu.SetActive(true);
        }
        else if (angle > hideMenuThreshold)
        {
        menu.SetActive(false);
        }
    }
}
