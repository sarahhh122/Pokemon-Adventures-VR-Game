using UnityEngine;
using System.Collections;

public class ScriptSerena : MonoBehaviour
{
    public Animator animator;           
    public string idleState = "Idle"; 
    
    public AudioSource audioSource;      
    public AudioClip talkClip;           

    public Transform walkDestination;  
    public float walkSpeed = 3f;      

    public float delayBeforeWave = 2f;
    public float waveDuration = 1.5f;
    public float delayAfterWave = 0.5f;

    void Start()
    {
        animator.Play(idleState);

        StartCoroutine(RunSequence());
    }

    IEnumerator RunSequence()
    {
        // 1. Idle
        yield return new WaitForSeconds(delayBeforeWave);

        // 2. Wave
        animator.SetTrigger("Wave");
        yield return new WaitForSeconds(waveDuration + delayAfterWave);

        // 3. Talk
        animator.SetTrigger("Talk");
        if (talkClip != null && audioSource != null)
        {
            audioSource.clip = talkClip;
            audioSource.Play();
            yield return new WaitForSeconds(talkClip.length);
        }
        else
        {
            // Delay if no audio clip is assigned
            yield return new WaitForSeconds(3f);
        }

        // 4. Walk
        animator.SetTrigger("Walk");
        while (Vector3.Distance(transform.position, walkDestination.position) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, walkDestination.position, walkSpeed * Time.deltaTime);
            yield return null;
        }

        // 5. Sit on canapé
        animator.SetTrigger("Sit");

    }
}
