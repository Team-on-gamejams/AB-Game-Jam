using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pancil_sound : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audioSource;
    public AudioClip clip;
    public float volume = 0.5f;

    public void CrossSound()
    {
        audioSource.PlayOneShot(clip);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
