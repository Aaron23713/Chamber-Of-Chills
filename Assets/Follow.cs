using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform theTarget;
    public Transform otherTarget;
    const float EPSILON = 0.1f;
     
    public float speed;
    bool updateWorthy = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(updateWorthy){
            otherTarget.transform.LookAt(theTarget.position);
           
            // if((otherTarget.transform.position - theTarget.position).magnitude > EPSILON){
                otherTarget.transform.Translate(0.0f,0.0f, speed * Time.deltaTime);
            // }
        }
    }
    public void newMeth(){
        updateWorthy = true;
    }
}
