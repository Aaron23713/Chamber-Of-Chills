using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using UnityEngine;

public class RotatingCrossWest : MonoBehaviour
{
    // Start is called before the first frame update
  
   public bool Rotating = false;
   public float elapsedTime = 0;
   public bool oneTime = false;
   
    void Start()
    {
        
    }

    // Update is called once per frame
void Update()
{
    if (Rotating)
    {
        if (elapsedTime < 5f)
        {
            Vector3 position = GetComponent<Renderer>().bounds.center;
            transform.RotateAround(position, Vector3.back, 35 * Time.deltaTime);
            elapsedTime += Time.deltaTime;
        }
        else
        {
            oneTime = true;
            Rotating = false;
        }
    }
}
    public void Beginning(){
    if(oneTime != true){
    Rotating = true;
    elapsedTime = 0f;
    }
    }
}
