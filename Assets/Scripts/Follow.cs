using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Follow : MonoBehaviour
{
    public Transform theTarget;
    public float stoppingDistance = 2.0f; // Adjust this distance as needed
    public float resumeDistance = 5.0f; // Adjust this distance as needed
    public float destroyDistance = 10.0f; // Adjust this distance as needed
    public AudioSource heartBeat;
    public AudioSource flatline;
    public int myHealth;

    public bool waiting = false;
    public NavMeshAgent navMeshAgent;
    public Animator animator;
    public heartMonitor heart;

    private bool hasPlayedAttackAnimation = false;

    void Start()
    {
        // ... (Other initialization code)
    }

    void Update()
    {
        if (!waiting)
        {
            float distanceToTarget = Vector3.Distance(transform.position, theTarget.position);

            Debug.Log("Distance to Target: " + distanceToTarget);

            // Check if the enemy is close to the player
            if (distanceToTarget <= stoppingDistance)
            {
                // Stop and play audio
                Debug.Log("Stopping");
                navMeshAgent.isStopped = true;
                heartBeat.Play();
                StartCoroutine(Timedelay());

                // Play the attack animation only once
                if (!hasPlayedAttackAnimation)
                {
                    // StartCoroutine(PlayAttackAnimation());
                    // hasPlayedAttackAnimation = true;
                }
            }
            else if (distanceToTarget > resumeDistance)
            {
                // Resume following the player
                Debug.Log("Resuming");
                navMeshAgent.isStopped = false;
                navMeshAgent.SetDestination(theTarget.position);

                // Reset the flag when resuming
                hasPlayedAttackAnimation = false;
            }

            // Check if the enemy is too far from the player, then destroy it
            if (distanceToTarget > destroyDistance)
            {
                Debug.Log("Destroying");
                Destroy(gameObject);
            }
        }
    }

    // ... (Other methods)

    // IEnumerator PlayAttackAnimation()
    // {
    //     // Play the attack animation by name
    //     animator.Play("Baruk_Attack_Bite_Front");

    //     // Wait for the attack animation to finish
    //     yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

    //     // Manually transition back to the default state
    //     animator.Play("Baruk_Sprint_Forward"); // Replace "EntryState" with the name of your default state
    // }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            // StartCoroutine(PlayAttackAnimation());
            heart.manualHeartIncrease();
            Debug.Log("HIT FOUND");
    
        }
    }
     IEnumerator Timedelay()
    {
        waiting = true;
        yield return new WaitForSeconds(5f);
        waiting = false;

        // Check if the player is still alive after the delay
        if (myHealth >= 10)
        {
            flatline.Play();
            Destroy(gameObject); // Destroy the enemy
        }
    }
}
