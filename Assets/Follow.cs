using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform theTarget;
    public Transform otherTarget;
    const float EPSILON = 0.1f;
     
     public Health myHealth;
    public float speed;
    // bool updateWorthy = false;

    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    public AudioSource heartBeat;
    public AudioSource flatline;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if(updateWorthy){
            otherTarget.transform.LookAt(theTarget.position);
           
            if((otherTarget.transform.position - theTarget.position).magnitude > EPSILON){
                otherTarget.transform.Translate(0.0f,0.0f, speed * Time.deltaTime);
            }
        // }
    }
    public void newMeth(){
        // updateWorthy = true;
    }

    public void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Player"){
            Debug.Log("HIT FOUND");
            if(myHealth.playerHealth >= 10){
                flatline.Play();
            }else{
            myHealth.playerHealth++;
            heartBeat.Play();
            // StartCoroutine(Timedelay());
           
            }
        }
    }
    IEnumerator Timedelay(){
        yield return new WaitForSeconds(10f);
    }
}
