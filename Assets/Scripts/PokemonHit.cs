using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PokemonHit : MonoBehaviour
{
    public int scoreValue = 20;
    public AudioClip goodJobClip;
    private AudioSource audioSource;
    public GameObject captureParticlesPrefab;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();
    }

    // Using trigger detection for the collision with the PokeBall
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PokeBall"))
        {
            CapturePokemon();
        }
    }

    void CapturePokemon()
    {
        ScoreManager.instance.AddScore(scoreValue);
        
        AudioSource.PlayClipAtPoint(goodJobClip, transform.position);

         if (captureParticlesPrefab != null)
        {
            GameObject particles = Instantiate(captureParticlesPrefab, transform.position, Quaternion.identity);
            ParticleSystem ps = particles.GetComponent<ParticleSystem>();
            if (ps != null)
            {
                Destroy(particles, ps.main.duration + ps.main.startLifetime.constantMax);
            }
            else
            {
                Destroy(particles, 0.5f);
            }
        }
        
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        foreach (Renderer r in renderers)
        {
            r.enabled = false;
        }
        Collider col = GetComponent<Collider>();
        if (col != null)
            col.enabled = false;
        
        Destroy(gameObject, goodJobClip.length);
    }
}