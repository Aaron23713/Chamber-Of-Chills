using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieControll : MonoBehaviour
{
    public Transform target;
    public float rotationSpeed = 5f;
    public GameObject zombieParent;

    // Update is called once per frame
    void Update()
    {
        LookAtPlayer();
    }

    void LookAtPlayer()
    {
        if (target != null)
        {
            // Calculate the direction to the player
            Vector3 directionToPlayer = target.position - transform.position;
            directionToPlayer.y = 0f; // Optional: Keep the zombie upright

            // Rotate the zombie to face the player
            if (directionToPlayer != Vector3.zero)
            {
                Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

                // Reset x and y components of the rotation
                lookRotation.x = 0;
                lookRotation.y = 0;

                // Assign the corrected rotation back to the transform
                transform.rotation = lookRotation;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("zombie"))
        {
            zombieParent.SetActive(true);
        }
    }
}