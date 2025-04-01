using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PokemonHit : MonoBehaviour
{
    public int scoreValue = 20;
    public AudioClip goodJobClip;
    private AudioSource audioSource;

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
        // Add score for capturing the Pokémon
        ScoreManager.instance.AddScore(scoreValue);
        
        // Play the "good job" sound at the Pokémon's position
        AudioSource.PlayClipAtPoint(goodJobClip, transform.position);
        
        // Optionally, hide the Pokémon's visuals immediately so it appears "captured"
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        foreach (Renderer r in renderers)
        {
            r.enabled = false;
        }
        Collider col = GetComponent<Collider>();
        if (col != null)
            col.enabled = false;
        
        // Destroy the Pokémon after the length of the sound so the clip can finish playing
        Destroy(gameObject, goodJobClip.length);
    }
}
