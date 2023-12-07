using System.Collections;
using UnityEngine;

public class WerewolfController : MonoBehaviour
{
    public Animator werewolfAnimator;
    public string scareLayerName = "ScareLayer";
    public string chaseLayerName = "ChaseLayer";

    void Start()
    {
        StartCoroutine(PlayScareThenChase());
    }

    IEnumerator PlayScareThenChase()
    {
        if (werewolfAnimator != null)
        {
            // Enable the scare layer and disable the chase layer
            werewolfAnimator.SetLayerWeight(werewolfAnimator.GetLayerIndex(scareLayerName), 1f);
            werewolfAnimator.SetLayerWeight(werewolfAnimator.GetLayerIndex(chaseLayerName), 0f);

            // Trigger the scare animation
            werewolfAnimator.SetTrigger("ScareTrigger");

            // Wait for 10 seconds
            yield return new WaitForSeconds(10f);

            // Enable the chase layer and disable the scare layer
            werewolfAnimator.SetLayerWeight(werewolfAnimator.GetLayerIndex(scareLayerName), 0f);
            werewolfAnimator.SetLayerWeight(werewolfAnimator.GetLayerIndex(chaseLayerName), 1f);

            // Trigger the chase animation
            werewolfAnimator.SetTrigger("ChaseTrigger");
        }
        else
        {
            Debug.LogError("Animator component not found on the GameObject.");
        }
    }
}
