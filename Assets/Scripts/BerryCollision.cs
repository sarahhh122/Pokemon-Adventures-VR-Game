using UnityEngine;

public class BerryCollision : MonoBehaviour
{
    public AudioSource berryAudioSource;

    public string pokemonTag = "Pokemon";

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(pokemonTag))
        {
            if (berryAudioSource != null)
            {
                berryAudioSource.Play();
            }

           
        }
    }
}

