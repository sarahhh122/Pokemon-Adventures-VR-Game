using UnityEngine;

public class DepositBox : MonoBehaviour
{
public AudioSource sfxSource;    

    public float itemPrice = 10f;  
    public float totalPrice = 0f;
    public string targetTag = "Item";  


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
        totalPrice += itemPrice;

        if (sfxSource != null)
        {
            sfxSource.PlayOneShot(sfxSource.clip, 2.0f);
        }
        }


    }
}

    
